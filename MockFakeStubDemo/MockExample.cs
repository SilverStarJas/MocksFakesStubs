using Moq;
using Xunit;

namespace MockFakeStubDemo;

// Verifying that the application is interacting with the logger properly
public class MockExample
{
    [Fact]
    public void Mock_ShouldVerifyInteractionWithLogger()
    {
        var mockLogger = new Mock<ILogger>();
        var mockRepo = new Mock<IDeliveryRepository>();
        mockRepo.Setup(repo => repo.GetDelivery(1)).Returns(new Delivery { Id = 1, Total = 100, Address = "367 Collins St" });

        var fakeDatabase = new FakeExample();
        var service = new DeliveryService(mockLogger.Object, fakeDatabase, mockRepo.Object);

        service.ProcessDelivery(1);

        mockLogger.Verify(logger => logger.Log("Delivery 1 processed."), Times.Once);
        mockLogger.Verify(logger => logger.Log("Total is 100."), Times.Once);
        mockLogger.Verify(logger => logger.Log("Address is 367 Collins St."), Times.Once);
    }
    
}