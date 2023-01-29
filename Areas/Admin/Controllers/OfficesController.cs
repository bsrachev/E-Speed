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
            var query = this.officeService.GetAllOffices();

            return View(query);
        }

        // GET: Office/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = this.data.Offices.FirstOrDefault(m => m.Id == id);

            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // GET: Office/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address")] Office office)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(office);
                this.data.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Office/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = this.data.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // POST: Office/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Name,Address")] Office office)
        {
            if (id != office.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this.data.Update(office);
                this.data.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Office/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = this.data.Offices
                .FirstOrDefault(m => m.Id == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }
    }
}