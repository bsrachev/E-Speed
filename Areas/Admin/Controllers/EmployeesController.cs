﻿namespace E_Speed.Areas.Admin.Controllers
{
    using E_Speed.Areas.Admin.Models.Employees;
    using E_Speed.Data;
    using E_Speed.Services.Users;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeesController : AdminController
    {
        private readonly IUserService userService;
        private readonly E_SpeedDbContext data;

        public EmployeesController(IUserService userService, E_SpeedDbContext data)
        {
            this.userService = userService;
            this.data = data;
        }

        public IActionResult Index()
        {
            var users = this.userService.GetAllUsers();

            var query = new EmployeeFormModel
            {
                users = users
            };

            return this.View(query);
        }

        /*[HttpPost]
        public IActionResult Index(EmployeeFormModel currencyModel)
        {
            if (this.currencyService.GetCurrencies().Any(c => c.Code == currencyModel.Code))
            {
                TempData[GlobalErrorKey] = CurrencyCodeAlreadyExists;
            }
            else if (this.currencyService.Add(currencyModel.Code) == 0)
            {
                TempData[GlobalErrorKey] = InvalidCurrencyCode;
            }
            else
            {
                TempData[GlobalSuccessKey] = SuccessfullyAddedCurrency;
            }

            var currencies = this.currencyService.GetCurrencies();
                
            return this.View(currencies);
        }

        public IActionResult Delete(int id)
        {
            if (id == 1 || id == 2)
            {
                TempData[GlobalErrorKey] = CannotDeleteEURorBGN;

                return this.RedirectToAction(nameof(Index));
            }

            this.currencyService.Delete(id);

            TempData[GlobalSuccessKey] = SuccessfullyDeletedCurrency;

            return this.RedirectToAction(nameof(Index));
        }*/
    }
}
