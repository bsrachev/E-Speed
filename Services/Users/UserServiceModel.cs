using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Speed.Services.Users
{
    public class UserServiceModel
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Display(Name = "Employee")]
        public bool IsEmployee { get; set; }

        [Display(Name = "Office Employee")]
        public bool IsOfficeEmployee { get; set; }

        [Display(Name = "Delivery Employee")]
        public bool IsDeliveryEmployee { get; set; }
    }
}
