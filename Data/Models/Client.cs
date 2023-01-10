using System.ComponentModel.DataAnnotations;

namespace E_Speed.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string HomeAddress { get; set; }

        public IEnumerable<Shipment> Shipments { get; set; }
    }
}
