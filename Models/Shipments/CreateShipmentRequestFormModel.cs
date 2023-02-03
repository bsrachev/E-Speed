using System.ComponentModel.DataAnnotations;

namespace E_Speed.Models.Shipments
{
    public class CreateShipmentRequestFormModel
    {
        [Required]
        public string ReceiverName { get; set; }

        [Required]
        public string ReceiverPhone { get; set; }

        [Required]
        public bool DeliveryToOffice { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Method { get; set; }
    }
}
