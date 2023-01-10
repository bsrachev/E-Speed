namespace E_Speed.Data.Models
{
    public class OfficeEmployee : Employee
    {
        public IEnumerable<Shipment> ShipmentsProcessed { get; set; }

        public Office Office { get; set; }

        public int OfficeId { get; set; }
    }
}
