using System.ComponentModel.DataAnnotations;

namespace E_Speed.Data.Models
{
    public class Office
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public IEnumerable<OfficeEmployee> OfficeEmployees { get; set; }
    }
}
