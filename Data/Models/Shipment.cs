using E_Speed.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Speed.Data.Models
{
    public class Shipment : BaseShipment
    {
        public int TrackingNumber { get; init; }

        [Required]
        public DateTime DateAccepted { get; init; }

        public DateTime DateDelivered { get; init; }

        public int? ReceiverId { get; init; }

        [NotMapped]
        public User? Receiver { get; init; }

        [Required]
        public decimal Weight { get; init; }

        [Required]
        public decimal Price { get; init; }

        public User ProcessedByOfficeEmployee { get; set; }

        [Required]
        public int ProcessedByOfficeEmployeeId { get; set; }

        public User AssignedToDeliveryEmployee { get; set; }

        [Required]
        public int AssignedToDeliveryEmployeeId { get; set; }
    }
}
