using E_Speed.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Speed.Data.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAccepted { get; init; }

        public User Sender { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public string ReceiverName { get; set; }

        [Required]
        public string ReceiverPhone { get; set; }

        public int? ReceiverId { get; set; }

        [NotMapped]
        public User Receiver { get; set; }

        [Required]
        public bool DeliveryToOffice { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string Description { get; set; }

        public User ProcessedByOfficeEmployee { get; set; }

        public int ProcessedByOfficeEmployeeId { get; set; }

        public User AssignedToDeliveryEmployee { get; set; }

        public int AssignedToDeliveryEmployeeId { get; set; }

        public decimal Price { get; set; }

        public ShipmentStatus Status { get; set; }
    }
}
