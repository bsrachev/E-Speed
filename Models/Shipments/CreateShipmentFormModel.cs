using System.ComponentModel.DataAnnotations;

namespace E_Speed.Models.Shipments
{
    public class CreateShipmentFormModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Accepted")]
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

        [Required]
        public decimal Price { get; set; }
    }
}
