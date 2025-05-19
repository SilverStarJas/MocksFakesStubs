namespace MockFakeStubDemo;

public class DeliveryService
{
    private readonly ILogger _logger;
    private readonly FakeExample _database;
    private readonly IDeliveryRepository _deliveryRepository;

    public DeliveryService(ILogger logger, FakeExample database, IDeliveryRepository deliveryRepository)
    {
        _logger = logger;
        _database = database;
        _deliveryRepository = deliveryRepository;
    }

    public void ProcessDelivery(int deliveryId)
    {
        var delivery = _deliveryRepository.GetDelivery(deliveryId);
        _database.CreateDelivery(delivery);
        _logger.Log($"Delivery {deliveryId} processed.");
        _logger.Log($"Total is {delivery.Total}.");
        _logger.Log($"Address is {delivery.Address}.");
    }
}
