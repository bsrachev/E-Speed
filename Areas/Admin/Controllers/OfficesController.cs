using E_Speed.Areas.Admin.Models.Offices;
using E_Speed.Data;
using E_Speed.Data.Models;
using E_Speed.Services.Offices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Speed.Areas.Admin.Controllers
{

    public class OfficesController : AdminController
    {
        private readonly IOfficeService officeService;
        private readonly E_SpeedDbContext data;

        public OfficesController(IOfficeService officeService, E_SpeedDbContext data)
        {
            this.officeService = officeService;
            this.data = data;
        }

        // GET: Office
        public IActionResult Index()
        {
            var query = new AllOfficesQueryModel
            {
                Offices = this.officeService.GetAllOffices()
            };

            return View(query);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new AllOfficesQueryModel
            {
                Offices = this.officeService.GetAllOffices(),
                OfficeId = id
            };

            return View("Index", query);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OfficeServiceModel model)
        {
            if (model.Id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var office = new Office
                {
                    Id = model.Id.Value,
                    Address = model.Address,
                    Name = model.Name
                };

                this.officeService.UpdateOffice(office);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Office/Create
        public IActionResult Create()
        {
            var query = new AllOfficesQueryModel
            {
                Offices = this.officeService.GetAllOffices(),
                OfficeId = 0
            };

            return View("Index", query);
        }

        // POST: Office/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OfficeServiceModel model)
        {
            if (model.Name != null && model.Address != null)
            {
                var office = new Office
                {
                    Address = model.Address,
                    Name = model.Name
                };

                this.officeService.AddOffice(office);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Office/Delete/5
        public IActionResult Delete(int id)
        {
            this.officeService.DeleteOffice(id);

            return RedirectToAction(nameof(Index));
        }
    }
}