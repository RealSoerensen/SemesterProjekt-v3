using Models;
using RESTful_API.Services;

namespace ApiTests;

[TestClass]
public class OrderTests
{
    private OrderService _orderService;

    [TestInitialize]
    public void Initialize()
    {
        _orderService = new OrderService();
    }

    [TestMethod]
    public async Task CreateOrder_WithValidOrderAndOrderlines_ReturnsOrder()
    {
        // Arrange
        var order = new Order(1);
        var orderlines = new List<Orderline>
        {
            new(1, 3, 18),
            new(2, 2, 12),
            new(3, 1, 114)
        };

        // Act
        var result = await _orderService.CreateOrder(order, orderlines);

        // Assert
        // Add assertions here to verify the expected behavior
        Assert.IsNotNull(result);
        Assert.AreEqual(order.ID, result.ID);
        Assert.AreEqual(order.CustomerID, result.CustomerID);
        Assert.AreEqual(order.Date, result.Date);
        Assert.AreEqual(order.Status, result.Status);
    }

    [TestMethod]
    public async Task GetAllOrders_ReturnsListOfOrders()
    {
        // Arrange

        // Act
        var result = await _orderService.GetAllOrders();

        // Assert
        // Add assertions here to verify the expected behavior
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(List<Order>));
        Assert.IsTrue(result.Count > 0);
    }
}