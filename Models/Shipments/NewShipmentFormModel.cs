using E_Speed.Services.Shipments;
using E_Speed.Services.Users;

namespace E_Speed.Models.Shipments
{
    public class NewShipmentFormModel
    {
        public ShipmentRequestServiceModel Request { get; set; }

        public CreateShipmentFormModel NewShipment { get; set; }

        public IEnumerable<UserServiceModel> DeliveryEmployeesList { get; set; }

        public IEnumerable<UserServiceModel> ClientsList { get; set; }
    }
}
