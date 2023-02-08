using E_Speed.Data.Models;
using E_Speed.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_Speed.Services.Shipments
{
    public class ShipmentRequestServiceModel
    {
        public int Id { get; set; }

        public User Sender { get; set; }
        
        [Display(Name = "Sender")]
        public int SenderId { get; set; }

        [Display(Name = "Receiver Name")]
        public string ReceiverName { get; set; }

        [Display(Name = "Receiver Phone")]
        public string ReceiverPhone { get; set; }

        [Display(Name = "Delivery To Office")]
        public bool DeliveryToOffice { get; set; }

        [Display(Name = "Office")]
        public int? OfficeId { get; set; }

        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        public string Description { get; set; }

        public ShippingMethod Method { get; set; }

        public ShipmentStatus Status { get; set; }

        [Display(Name = "System Comment")]
        public string SystemComment { get; set; }
    }
}