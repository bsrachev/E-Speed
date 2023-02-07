using System.ComponentModel.DataAnnotations;

namespace E_Speed.Models.Shipments
{
    public class CreateShipmentFormModel
    {
        [Display(Name = "Receiver")]
        public int ReceiverId { get; set; }

        [Required]
        [Display(Name = "Receiver Name")]
        public string ReceiverName { get; set; }

        [Required]
        [Display(Name = "Receiver Phone")]
        public string ReceiverPhone { get; set; }

        [Required]
        [Display(Name = "Delivery To Office")]
        public bool DeliveryToOffice { get; set; }

        [Required]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Assign To Delivery Employee")]
        public int AssignedToDeliveryEmployeeId { get; set; }
    }
}
