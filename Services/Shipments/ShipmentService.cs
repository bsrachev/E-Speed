using E_Speed.Data;

namespace E_Speed.Services.Shipments
{
    public class ShipmentService : IShipmentService
    {
        private readonly E_SpeedDbContext data;

        public ShipmentService(
            E_SpeedDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ShipmentServiceModel> GetAllShipments()
        {
            var ordersQuery = this.data.Shipments.AsQueryable();

            return ordersQuery
                .OrderByDescending(c => c.DateAccepted)
                .Select(c => new ShipmentServiceModel
                {
                    Id = c.Id,
                    AssignedToDeliveryEmployeeId = c.AssignedToDeliveryEmployeeId,
                    DateAccepted = c.DateAccepted,
                    DeliveryAddress = c.DeliveryAddress,
                    Description = c.Description,
                    Receiver = c.Receiver,
                    Sender = c.Sender,
                    Weight = c.Weight,
                    Price = c.Price,
                    ProcessedByOfficeEmployeeId = c.ProcessedByOfficeEmployeeId,
                    DeliveryToOffice = c.DeliveryToOffice,
                    AssignedToDeliveryEmployee = c.AssignedToDeliveryEmployee,
                    ProcessedByOfficeEmployee = c.ProcessedByOfficeEmployee,
                    Status = c.Status
                })
                .ToList();
        }
    }
}
