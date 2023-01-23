using E_Speed.Models.Shipments;

namespace E_Speed.Services.Shipments
{
    public interface IShipmentService
    {
        int Create(string sender, string receiver, DateTime dateAccepted, bool deliveryToOffice, string deliveryAddress, string description, decimal price, decimal weight, int v);
        
        IEnumerable<ShipmentServiceModel> GetAllShipments(); //TODO (OrderSearchFormModel searchModel = null)

        ShipmentDetailListingViewModel GetShipmentById(int shipmentId);
    }
}
