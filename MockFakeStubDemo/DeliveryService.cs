namespace MockFakeStubDemo;

public class DeliveryService
{
    private readonly ILogger _logger;
    private readonly IDeliveryRepository _deliveryRepository;

    public DeliveryService(ILogger logger, IDeliveryRepository deliveryRepository)
    {
        _logger = logger;
        _deliveryRepository = deliveryRepository;
    }

    public void ProcessDelivery(int deliveryId)
    {
        var delivery = _deliveryRepository.GetDelivery(deliveryId);
        _logger.Log($"Delivery {deliveryId} processed.");
        _logger.Log($"Total is {delivery.Total}.");
        _logger.Log($"Address is {delivery.Address}.");
    }
}
