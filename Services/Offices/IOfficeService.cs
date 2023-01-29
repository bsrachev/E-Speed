﻿using E_Speed.Data.Models;

namespace E_Speed.Services.Offices
{
    public interface IOfficeService
    {
        public void AddOffice(Office office);

        public OfficeServiceModel GetOfficeById(string id);

        public IEnumerable<OfficeServiceModel> GetAllOffices();

        public void UpdateOffice(Office office);

        public void DeleteOffice(string id);
    }
}