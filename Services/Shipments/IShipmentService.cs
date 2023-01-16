namespace E_Speed.Services.Shipments
{
    public interface IShipmentService
    {
        IEnumerable<ShipmentServiceModel> GetAllShipments(); //TODO (OrderSearchFormModel searchModel = null)
    }
}
