namespace MockFakeStubDemo;

public class FakeDeliveryRepository : IDeliveryRepository
{
    public int NumberCalled { get; private set; }
    public int DeliveryIdReceived { get; private set; }
    
    public Delivery? GetDelivery(int deliveryId)
    {
        NumberCalled++;
        DeliveryIdReceived = deliveryId;

        return new Delivery
        {
            Id = deliveryId
        };
    }
}