namespace E_Speed.Data.Models
{
    using static DataConstants.User;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser<int>
    {
        [Required]
        public bool IsEmployee { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public IEnumerable<Shipment> PersonalShipments { get; set; } // for Clients

        public IEnumerable<Shipment> ShipmentsProcessed { get; set; } // for Delivery Employees

        //public Office Office { get; set; } // for Office Employees

        //public string OfficeId { get; set; } // for Office Employees

        public IEnumerable<Shipment> ShipmentsAssigned { get; set; } // for Office Employees
    }
}
