using Microsoft.EntityFrameworkCore;

namespace MockFakeStubDemo;

// Database that would be used by the actual application with a few extra methods compared to the fake
public class RealDeliveryRepository : IDeliveryRepository
{
    private readonly DbContext _context;
    public RealDeliveryRepository(DbContext context) => _context = context;

    public Delivery? GetDelivery(int deliveryId)
    {
       return  _context
            .Set<Delivery>()
            .FirstOrDefault(d => d.Id == deliveryId);
    }
}