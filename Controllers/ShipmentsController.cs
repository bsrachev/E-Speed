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

namespace E_Speed.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly E_SpeedDbContext _context;
        private readonly IShipmentService shipmentService;

        public ShipmentsController(E_SpeedDbContext context, IShipmentService shipmentService)
        {
            _context = context;
            this.shipmentService = shipmentService;
        }

        // GET: Shipments
        //[Authorize]
        public IActionResult Index([FromQuery] AllShipmentQueryModel query)
        {
            query.Shipments = this.shipmentService.GetAllShipments();

            return this.View(query);
        }

        [Authorize]
        public IActionResult CreateRequest()
        {
            return this.View();
        }

        // GET: Shipments/Details/5
        /*public async Task<IActionResult> Details(int? id)
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
        }*/

        // GET: Shipments/Create
        public IActionResult Create()
        {
            //ViewData["AssignedToDeliveryEmployeeId"] = new SelectList(_context.DeliveryEmployees, "Id", "Name");
            //ViewData["ProcessedByOfficeEmployeeId"] = new SelectList(_context.OfficeEmployees, "Id", "Name");
            return this.View();
        }

        // POST: Shipments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateShipmentFormModel shipmentModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(shipmentModel);
            }

            int shipmentId = this.shipmentService.Create(this.User.Id(),
                                                         shipmentModel.Receiver,
                                                         shipmentModel.Receiver,
                                                         shipmentModel.DateAccepted,
                                                         shipmentModel.DeliveryToOffice,
                                                         shipmentModel.DeliveryAddress,
                                                         shipmentModel.Description,
                                                         shipmentModel.Price,
                                                         shipmentModel.Weight); 
            
            //var a = this.User.Id();

            return this.Redirect($"/Shipments/Details/?shipmentId={shipmentId}");
        }

        //[Authorize]
        public IActionResult Details(int? shipmentId)
        {
            if (shipmentId == null) // || _context.Shipments == null)
            {
                return NotFound();
            }

            var query = this.shipmentService.GetShipmentById(shipmentId.Value);

            return View(query);
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
                return Problem("Entity set 'E_SpeedDbContext.Shipments'  is null.");
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
