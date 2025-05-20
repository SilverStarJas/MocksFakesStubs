using Moq;
using Xunit;

namespace MockFakeStubDemo;

// Verifying that the application is interacting with the logger properly
public class Tests
{
    [Fact]
    public void Mock_ShouldVerifyInteractionWithLogger()
    {
        // Arrange
        var mockLogger = new Mock<ILogger>();
        var mockRepo = new Mock<IDeliveryRepository>();
        mockRepo.Setup(repo => repo.GetDelivery(1)).Returns(new Delivery { Id = 1, Total = 100, Address = "367 Collins St" });

        var service = new DeliveryService(mockLogger.Object, mockRepo.Object);

        // Act
        service.ProcessDelivery(1);

        // Assert
        mockRepo.Verify(repo => repo.GetDelivery(1), Times.Once);
        mockLogger.Verify(logger => logger.Log("Delivery 1 processed."), Times.Once);
        mockLogger.Verify(logger => logger.Log("Total is 100."), Times.Once);
        mockLogger.Verify(logger => logger.Log("Address is 367 Collins St."), Times.Once);
    }

    [Fact]
    public void Stub()
    {
        // Arrange
        var loggerStub = new LoggerStub();
        var deliveryRepositoryStub = new DeliveryRepositoryStub();
        
        var service = new DeliveryService(loggerStub, deliveryRepositoryStub);
        
        // Act
        service.ProcessDelivery(1);
        
        // Assert
        // Stubs generally doesn't support verify
    }

    [Fact]
    public void Fake()
    {
        // Arrange
        var loggerStub = new LoggerStub();
        var repositoryFake = new FakeDeliveryRepository();
        
        var service = new DeliveryService(loggerStub, repositoryFake);

        var deliveryOrderId = 1;
        
        // Act
        service.ProcessDelivery(deliveryOrderId);
        
        // Assert
        Assert.Equal(1, repositoryFake.NumberCalled);
        Assert.Equal(deliveryOrderId, repositoryFake.DeliveryIdReceived);
    }
}