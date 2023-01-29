namespace E_Speed.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ShippingMethod
    {
        [Display(Name = "Standard")]
        New = 0,

        [Display(Name = "Express")]
        Accepted = 1,

        [Display(Name = "Overnight")]
        Shipped = 2
    }
}
