using E_Speed.Data.Models;
using E_Speed.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_Speed.Models.Shipments
{
    public class ShipmentDetailListingViewModel
    {
        public int Id { get; init; }

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

        [Required]
        public int ProcessedByOfficeEmployeeId { get; set; }

        [Required]
        public int AssignedToDeliveryEmployeeId { get; set; }

        [Required]
        public ShipmentStatus Status { get; set; }
    }
}
