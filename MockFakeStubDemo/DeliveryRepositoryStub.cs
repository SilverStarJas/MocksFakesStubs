namespace MockFakeStubDemo;

// Simplified version of a database
public class DeliveryRepositoryStub : IDeliveryRepository
{
    public Delivery? GetDelivery(int deliveryId)
    {
        return new Delivery
        {
            Id = deliveryId
        };
    }
}