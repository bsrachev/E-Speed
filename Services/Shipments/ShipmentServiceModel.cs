using E_Speed.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Speed.Services.Shipments
{
    public class ShipmentServiceModel
    {
        public int Id { get; set; }

        public DateTime DateAccepted { get; init; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public bool DeliveryToOffice { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal Weight { get; set; }

        public string Description { get; set; }

        public OfficeEmployee ProcessedByOfficeEmployee { get; set; }

        public int ProcessedByOfficeEmployeeId { get; set; }

        public DeliveryEmployee AssignedToDeliveryEmployee { get; set; }

        public int AssignedToDeliveryEmployeeId { get; set; }

        public decimal Price { get; set; }

        public int Status { get; set; }
    }
}
