using E_Speed.Data.Models;
using E_Speed.Models.Shipments;

namespace E_Speed.Services.Shipments
{
    public interface IShipmentService
    {
        int CreateShipment(int senderId, int receiverId, string receiverName, string receiverPhone, DateTime dateAccepted, bool deliveryToOffice, string deliveryAddress, string description, decimal price, decimal weight);
        
        int CreateShipmentRequest(ShipmentRequest shipmentRequest);

        IEnumerable<ShipmentServiceModel> GetAllShipments(); //TODO (OrderSearchFormModel searchModel = null)

        IEnumerable<ShipmentRequestServiceModel> GetAllShipmentRequests();

        ShipmentDetailListingViewModel GetShipmentById(int shipmentId);

        ShipmentRequestServiceModel GetShipmentRequestById(int requestId);
    }
}
