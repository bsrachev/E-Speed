using E_Speed.Data.Models.Enums;

namespace E_Speed.Services.Shipments
{
    public class ShipmentRequestServiceModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }   

        public string ReceiverName { get; set; }

        public string ReceiverPhone { get; set; }

        public bool DeliveryToOffice { get; set; }

        public int? OfficeId { get; set; }

        public string DeliveryAddress { get; set; }

        public string Description { get; set; }

        public ShippingMethod Method { get; set; }

        public ShipmentStatus Status { get; set; }

        public string EmployeeComment { get; set; }
    }
}