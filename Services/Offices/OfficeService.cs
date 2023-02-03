using E_Speed.Data;
using E_Speed.Data.Models;

namespace E_Speed.Services.Offices
{
    public class OfficeService : IOfficeService
    {
        private readonly E_SpeedDbContext data;

        public OfficeService(E_SpeedDbContext data)
            => this.data = data;

        public void AddOffice(Office office)
        {
            this.data.Offices.Add(office);

            this.data.SaveChanges();
        }

        public OfficeServiceModel GetOfficeById(int id)
        {
            var office = this.data.Offices.FirstOrDefault(o => o.Id == id);

            var query = new OfficeServiceModel
            {
                Id = office.Id,
                Name = office.Name,
                Address = office.Address
            };

            return query;
        }

        public IEnumerable<OfficeServiceModel> GetAllOffices()
        {
            var query = this.data.Offices
                .OrderBy(o => o.Name)
                .Select(o => new OfficeServiceModel 
                { 
                    Id = o.Id,
                    Name = o.Name,
                    Address = o.Address
                })
                .ToList();

            return query;
        }

        public void UpdateOffice(Office office)
        {
            var existingOffice = this.data.Offices.Find(office.Id);
            if (existingOffice == null)
            {
                return;
            }

            existingOffice.Name = office.Name;
            existingOffice.Address = office.Address;
            this.data.SaveChanges();
        }

        public void DeleteOffice(int id)
        {
            var existingOffice = this.data.Offices.Find(id);
            if (existingOffice == null)
            {
                return;
            }

            this.data.Offices.Remove(existingOffice);
            this.data.SaveChanges();
        }
    }
}
