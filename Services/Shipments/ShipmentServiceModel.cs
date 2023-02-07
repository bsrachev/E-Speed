using E_Speed.Data.Models;
using E_Speed.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Speed.Services.Shipments
{
    public class ShipmentServiceModel
    {
        public int Id { get; set; }

        public DateTime DateAccepted { get; init; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public bool DeliveryToOffice { get; set; }

        public int? OfficeId { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal Weight { get; set; }

        public string Description { get; set; }

        public User ProcessedByOfficeEmployee { get; set; }

        public int ProcessedByOfficeEmployeeId { get; set; }

        public User AssignedToDeliveryEmployee { get; set; }

        public int AssignedToDeliveryEmployeeId { get; set; }

        public decimal Price { get; set; }

        public ShipmentStatus Status { get; set; }
    }
}
