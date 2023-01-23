using System.ComponentModel.DataAnnotations;

namespace E_Speed.Data.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAccepted { get; init; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Receiver { get; set; }

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

        public int Status { get; set; }
    }
}
