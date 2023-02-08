using E_Speed.Data.Models;
using E_Speed.Models.Shipments;

namespace E_Speed.Services.Shipments
{
    public interface IShipmentService
    {
        int CreateShipment(int senderId,
                          int receiverId,
                          string receiverName,
                          string receiverPhone,
                          DateTime dateAccepted,
                          bool deliveryToOffice,
                          int? officeId,
                          string deliveryAddress,
                          string description,
                          decimal price,
                          decimal weight,
                          int assignedToDeliveryEmployeeId,
                          int processedByOfficeEmployeeId);

        int CreateShipmentRequest(ShipmentRequest shipmentRequest);

        IEnumerable<ShipmentServiceModel> GetAllShipments(); //TODO (OrderSearchFormModel searchModel = null)

        IEnumerable<ShipmentRequestServiceModel> GetAllShipmentRequests();

        ShipmentDetailListingViewModel GetShipmentById(int shipmentId);

        ShipmentRequestServiceModel GetShipmentRequestById(int requestId);

        public void DeleteShipmentRequest(int requestId);

        void Deliver(int shipmentId);

        void DeclineRequest(int requestId);
    }
}
