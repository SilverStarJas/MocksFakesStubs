namespace MockFakeStubDemo;

public interface ILogger
{
    void Log(string message);
}

public interface IDeliveryRepository
{
    Delivery GetDelivery(int deliveryId);
}
