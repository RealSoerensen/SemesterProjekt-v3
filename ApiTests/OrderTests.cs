using System.Collections;
using Models;
using RESTful_API.Services;

namespace ApiTests;

[TestClass]
public class OrderTests
{
    private readonly OrderService orderService;
    private readonly CustomerService customerService;
    private readonly OrderlineService orderlineService;

    public OrderTests()
    {
        orderService = new OrderService();
        customerService = new CustomerService();
        orderlineService = new();
    }

    [TestMethod]
    public async Task TestCreateOrder()
    {
        //Arrange
        var order = new Order(DateTime.UtcNow, 0, 1, Status.Pending);
        List<Orderline> orderlines = new List<Orderline>();
        var orderline = new Orderline(1, 10, 1, 0);
        orderlines.Add(orderline);

        //Act
        var createdOrder = await orderService.CreateOrder(order, orderlines);

        //Assert
        Assert.IsNotNull(createdOrder);
    }

    [TestMethod]
    public async Task TestGetOrder()
    {

    }

    [TestMethod]
    public async Task TestGetAllOrders()
    {

    }

    [TestMethod]
    public async Task TestUpdateOrder()
    {

    }

    [TestCleanup]
    public async Task Cleanup()
    {
    }
}