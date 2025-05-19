namespace MockFakeStubDemo;

// Simplified version of a database
public class FakeExample
{
    private readonly List<Delivery> _deliveries = new List<Delivery>();

    public void CreateDelivery(Delivery delivery)
    {
        _deliveries.Add(delivery);
    }

    public List<Delivery> GetAllOrders() => _deliveries;
}