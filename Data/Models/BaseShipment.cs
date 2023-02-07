using E_Speed.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Speed.Data.Models
{
    public class BaseShipment
    {
        public int Id { get; init; }

        public User Sender { get; init; }

        [Required]
        public int SenderId { get; init; }

        [Required]
        public string ReceiverName { get; set; }

        [Required]
        public string ReceiverPhone { get; set; }

        [Required]
        public bool DeliveryToOffice { get; set; }

        public int? OfficeId { get; init; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string Description { get; set; }

        public ShippingMethod Method { get; set; }

        public ShipmentStatus Status { get; set; }
    }
}
