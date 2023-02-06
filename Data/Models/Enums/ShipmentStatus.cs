namespace E_Speed.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ShipmentStatus
    {
        [Display(Name = "New Request")]
        New = 0,

        [Display(Name = "Accepted")]
        Accepted = 1,

        [Display(Name = "Shipped")]
        Shipped = 2,

        [Display(Name = "Pending Pickup")]
        PendingPickup = 3,

        [Display(Name = "Delivered")]
        Delivered = 4,

        [Display(Name = "Returned")]
        Returned = 5,

        [Display(Name = "Shipment Request Denied")]
        RequestDenied = 6
    }
}
