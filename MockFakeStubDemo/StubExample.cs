using Moq;
using Xunit;

namespace MockFakeStubDemo;

// Pre-define what is expected to be returned and assert to verify that it retrieves and returns the correct values
public class StubExample
{
    [Fact]
    public void GetOrder_ShouldReturnStubbedOrder()
    {
        var mockRepo = new Mock<IDeliveryRepository>();
        mockRepo.Setup(repo => repo.GetDelivery(1)).Returns(new Delivery { Id = 1, Total = 50, Address = "367 Collins St" });

        var delivery = mockRepo.Object.GetDelivery(1);

        Assert.Equal(1, delivery.Id);
        Assert.Equal(50, delivery.Total);
        Assert.Equal("367 Collins St", delivery.Address);
    }
}