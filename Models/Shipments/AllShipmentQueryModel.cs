using E_Speed.Services.Shipments;

namespace E_Speed.Models.Shipments
{
    public class AllShipmentQueryModel
    {
        public IEnumerable<ShipmentServiceModel> Shipments { get; set; }
    }
}
