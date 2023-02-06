﻿using E_Speed.Data;
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
                          string receiverName,
                          string receiverPhone,
                          DateTime dateAccepted,
                          bool deliveryToOffice,
                          string deliveryAddress,
                          string description,
                          decimal price,
                          decimal weight)
        {
            var shipment = new Shipment
            {
                SenderId = senderId,
                ReceiverName = receiverName,
                ReceiverPhone = receiverPhone,
                DateAccepted = dateAccepted,
                DeliveryToOffice = deliveryToOffice,
                DeliveryAddress = deliveryAddress,
                Description = description,
                Price = price,
                Weight = weight,
                Status = ShipmentStatus.New,
                AssignedToDeliveryEmployeeId = 0,
                ProcessedByOfficeEmployeeId = 0
            };

            this.data.Shipments.Add(shipment);

            this.data.SaveChanges();

            return shipment.Id;
        }

        public int CreateShipmentRequest(ShipmentRequest shipmentRequest)
        {
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
    }
}
