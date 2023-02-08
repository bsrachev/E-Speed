using E_Speed.Data;
using E_Speed.Data.Models;
using E_Speed.Data.Models.Enums;
using E_Speed.Models.Shipments;
using E_Speed.Infrastructure;

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

        public int CreateShipment(int senderId,
                          int receiverId,
                          string receiverName,
                          string receiverPhone,
                          DateTime dateAccepted,
                          bool deliveryToOffice,
                          int? officeId,
                          string deliveryAddress,
                          string description,
                          decimal price,
                          decimal weight,
                          int assignedToDeliveryEmployeeId,
                          int processedByOfficeEmployeeId)
        {
            var shipment = new Shipment
            {
                SenderId = senderId,
                ReceiverName = receiverName,
                ReceiverPhone = receiverPhone,
                DateAccepted = dateAccepted,
                DeliveryToOffice = deliveryToOffice,
                OfficeId = officeId,
                DeliveryAddress = deliveryAddress,
                Description = description,
                Price = price,
                Weight = weight,
                Status = ShipmentStatus.New,
                AssignedToDeliveryEmployeeId = assignedToDeliveryEmployeeId,
                ProcessedByOfficeEmployeeId = processedByOfficeEmployeeId
            };

            this.data.Shipments.Add(shipment);

            this.data.SaveChanges();

            return shipment.Id;
        }

        public int CreateShipmentRequest(ShipmentRequest shipmentRequest)
        {
            shipmentRequest.SystemComment = "Awaiting processing";

            this.data.ShipmentRequests.Add(shipmentRequest);

            this.data.SaveChanges();

            return shipmentRequest.Id;
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
                    Receiver = c.ReceiverName,
                    Sender = c.Sender.FullName,
                    SenderId = c.SenderId,
                    ReceiverId = c.ReceiverId,
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

        public IEnumerable<ShipmentRequestServiceModel> GetAllShipmentRequests()
        {
            var shipmentRequestsQuery = this.data.ShipmentRequests.AsQueryable();

            return shipmentRequestsQuery
                .Select(c => new ShipmentRequestServiceModel
                {
                    Id = c.Id,
                    Sender = c.Sender,
                    SenderId = c.SenderId,
                    ReceiverName = c.ReceiverName,
                    ReceiverPhone = c.ReceiverPhone,
                    Method = c.Method,
                    DeliveryAddress = c.DeliveryAddress,
                    Description = c.Description,
                    DeliveryToOffice = c.DeliveryToOffice,
                    Status = c.Status
                })
                .ToList();
        }

        public ShipmentDetailListingViewModel GetShipmentById(int shipmentId)
        {
            var shipment = this.data.Shipments.Where(x => x.Id == shipmentId).FirstOrDefault();

            var query = new ShipmentDetailListingViewModel
            {
                Id = shipment.Id,
                Sender = shipment.Sender.FullName,
                Receiver = shipment.ReceiverName,
                DateAccepted = shipment.DateAccepted,
                DeliveryAddress = shipment.DeliveryAddress,
                DeliveryToOffice = shipment.DeliveryToOffice,
                Description = shipment.Description,
                Price = shipment.Price,
                Weight = shipment.Weight
            };

            return query;
        }

        public ShipmentRequestServiceModel GetShipmentRequestById(int requestId)
        {
            var shipment = this.data.ShipmentRequests.Where(x => x.Id == requestId).FirstOrDefault();

            var query = new ShipmentRequestServiceModel
            {
                Id = shipment.Id,
                SystemComment = shipment.SystemComment,
                Method = shipment.Method,
                ReceiverName = shipment.ReceiverName,
                ReceiverPhone = shipment.ReceiverPhone,
                Sender = shipment.Sender,
                SenderId = shipment.SenderId,
                Status = shipment.Status,
                DeliveryAddress = shipment.DeliveryAddress,
                DeliveryToOffice = shipment.DeliveryToOffice,
                Description = shipment.Description
            };

            return query;
        }

        public void DeleteShipmentRequest(int requestId)
        {
            var shipment = this.data.ShipmentRequests.Find(requestId);

            if (shipment != null)
            {
                this.data.ShipmentRequests.Remove(shipment);

                this.data.SaveChanges();
            }
        }
    }
}
