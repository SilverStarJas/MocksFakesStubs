namespace MockFakeStubDemo;

// Database that would be used by the actual application with a few extra methods compared to the fake
public class RealDatabase
{
    private readonly List<Delivery> _deliveries = new List<Delivery>();

    public void CreateDelivery(Delivery delivery)
    {
        _deliveries.Add(delivery);
    }

    public List<Delivery> GetAllOrders() => _deliveries;

    public void CancelDelivery(Delivery delivery)
    {
        _deliveries.Remove(delivery);
    }

    public Delivery? EditDelivery(int deliveryId)
    {
        var result = _deliveries.FirstOrDefault(delivery => delivery.Id == deliveryId);
        
        return result;
    }
}