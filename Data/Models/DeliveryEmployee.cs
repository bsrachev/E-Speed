namespace E_Speed.Data.Models
{
    public class DeliveryEmployee : Employee
    {
        public IEnumerable<Shipment> ShipmentsAssigned { get; set; }
    }
}
