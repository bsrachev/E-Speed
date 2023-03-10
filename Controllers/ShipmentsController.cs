using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Speed.Data;
using E_Speed.Data.Models;
using Microsoft.AspNetCore.Authorization;
using E_Speed.Models.Shipments;
using E_Speed.Services.Shipments;
using E_Speed.Infrastructure;
using E_Speed.Data.Models.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using E_Speed.Services.Offices;
using E_Speed.Services.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace E_Speed.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly E_SpeedDbContext _context;
        private readonly IShipmentService shipmentService;
        private readonly IOfficeService officeService;
        private readonly IUserService userService;

        public ShipmentsController(E_SpeedDbContext context,
                                   IShipmentService shipmentService,
                                   IOfficeService officeService,
                                   IUserService userService)
        {
            _context = context;
            this.shipmentService = shipmentService;
            this.officeService = officeService;
            this.userService = userService;
        }

        // GET: Shipments
        [Authorize]
        public IActionResult Index([FromQuery] AllShipmentQueryModel query)
        {
            if (this.User.IsOfficeEmployee())
            {
                query.ShipmentRequests = this.shipmentService.GetAllShipmentRequests();
                query.Shipments = this.shipmentService.GetAllShipments();
            }
            else
            {
                query.ShipmentRequests = this.shipmentService.GetAllShipmentRequests()
                    .Where(r => r.SenderId == this.User.Id());
                query.Shipments = this.shipmentService.GetAllShipments()
                    .Where(r => r.SenderId == this.User.Id() || 
                           r.ReceiverId == this.User.Id() ||
                           r.AssignedToDeliveryEmployeeId == this.User.Id());
            }

            return this.View(query);
        }

        [Authorize]
        public IActionResult CreateRequest()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRequest(CreateShipmentRequestFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var shipmentRequest = new ShipmentRequest
            {
                SenderId = this.User.Id(),
                ReceiverName = model.ReceiverName,
                ReceiverPhone = model.ReceiverPhone,
                DeliveryToOffice = model.DeliveryToOffice,
                DeliveryAddress = model.DeliveryAddress,
                Description = model.Description,
                Method = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), model.Method, true),
                Status = 0
            };

            this.shipmentService.CreateShipmentRequest(shipmentRequest);

            return this.RedirectToAction("Index");
        }

        // GET: Shipments/ProcessRequest
        public IActionResult ProcessRequest(int requestId)
        {
            var query = new NewShipmentFormModel
            {
                Request = this.shipmentService.GetShipmentRequestById(requestId),
                NewShipment = new CreateShipmentFormModel(),
                ClientsList = this.userService.GetAllUsers().Where(c => c.Id != 1),
                DeliveryEmployeesList = this.userService.GetAllUsers().Where(u => u.IsDeliveryEmployee == true),
                OfficesList = this.officeService.GetAllOffices()
            };

            return this.View(query);
        }

        // POST: Shipments/ProcessRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessRequest(NewShipmentFormModel shipmentModel, int requestId)
        {
            if (!ModelState.IsValid)
            {
                shipmentModel.Request = this.shipmentService.GetShipmentRequestById(requestId);
                shipmentModel.ClientsList = this.userService.GetAllUsers().Where(c => c.Id != 1);
                shipmentModel.DeliveryEmployeesList = this.userService.GetAllUsers().Where(u => u.IsDeliveryEmployee == true);
                shipmentModel.OfficesList = this.officeService.GetAllOffices();

                if (ModelState.Values.Where(x => x.ValidationState == ModelValidationState.Invalid).Count() != 1)
                {
                    return this.View(shipmentModel);
                }
            }

            var request = this.shipmentService.GetShipmentRequestById(requestId);

            var newShipment = shipmentModel.NewShipment;

            var deliveryAddress = "";

            if (request.DeliveryToOffice == false)
            {
                deliveryAddress = newShipment.DeliveryAddress;
            }
            else
            {
                deliveryAddress = request.DeliveryAddress;
            }

            int shipmentId = this.shipmentService.CreateShipment(request.SenderId,
                                                         newShipment.ReceiverId,
                                                         newShipment.ReceiverName,
                                                         newShipment.ReceiverPhone,
                                                         DateTime.Now,
                                                         request.DeliveryToOffice,
                                                         newShipment.OfficeId,
                                                         deliveryAddress,
                                                         newShipment.Description,
                                                         newShipment.Price,
                                                         newShipment.Weight,
                                                         newShipment.AssignedToDeliveryEmployeeId,
                                                         this.User.Id());

            this.shipmentService.DeleteShipmentRequest(requestId);

            return this.RedirectToAction("Index");
        }

        //[Authorize]
        public IActionResult Details(int shipmentId)
        {
            if (shipmentId == null) // || _context.Shipments == null)
            {
                return NotFound();
            }

            var query = this.shipmentService.GetShipmentById(shipmentId);

            return View(query);
        }

        public IActionResult Deliver(int shipmentId)
        {
            if (shipmentId == null) // || _context.Shipments == null)
            {
                return NotFound();
            }

            this.shipmentService.Deliver(shipmentId);

            return RedirectToAction("Index");
        }

        public IActionResult DeclineRequest(int requestId)
        {
            if (requestId == null) // || _context.Shipments == null)
            {
                return NotFound();
            }

            this.shipmentService.DeclineRequest(requestId);

            return RedirectToAction("Index");
        }

        // GET: Shipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shipments == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            //ViewData["AssignedToDeliveryEmployeeId"] = new SelectList(_context.DeliveryEmployees, "Id", "Name", shipment.AssignedToDeliveryEmployeeId);
            //ViewData["ProcessedByOfficeEmployeeId"] = new SelectList(_context.OfficeEmployees, "Id", "Name", shipment.ProcessedByOfficeEmployeeId);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateAccepted,Sender,Receiver,DeliveryToOffice,DeliveryAddress,Weight,Description,ProcessedByOfficeEmployeeId,AssignedToDeliveryEmployeeId,Price,Status")] Shipment shipment)
        {
            if (id != shipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipmentExists(shipment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AssignedToDeliveryEmployeeId"] = new SelectList(_context.DeliveryEmployees, "Id", "Name", shipment.AssignedToDeliveryEmployeeId);
            //ViewData["ProcessedByOfficeEmployeeId"] = new SelectList(_context.OfficeEmployees, "Id", "Name", shipment.ProcessedByOfficeEmployeeId);
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shipments == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipments
                .Include(s => s.AssignedToDeliveryEmployee)
                .Include(s => s.ProcessedByOfficeEmployee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shipments == null)
            {
                return Problem("Entity set 'E_SpeedDbContext.Shipments' is null.");
            }
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipments.Any(e => e.Id == id);
        }
    }
}
