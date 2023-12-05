using RESTful_API.Services;

namespace ApiTests;

[TestClass]
public class OrderTests
{
    private readonly OrderService orderService;
    private readonly CustomerService customerService;

    public OrderTests()
    {
        orderService = new OrderService();
        customerService = new CustomerService();
    }

    [TestMethod]
    public void TestCreateOrder()
    {

    }

    [TestMethod]
    public void TestGetOrder()
    {

    }

    [TestMethod]
    public void TestGetAllOrders()
    {

    }

    [TestMethod]
    public void TestUpdateOrder()
    {

    }

    [TestCleanup]
    public void Cleanup()
    {
    }
}