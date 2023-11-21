using Models;
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
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(newCustomer).Result;
        var newOrder = new Order((long)createdCustomer.ID);

        // Act
        var createdOrder = orderService.CreateOrder(newOrder).Result;

        // Assert
        Assert.IsNotNull(createdOrder);
    }

    [TestMethod]
    public void TestGetOrder()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(newCustomer).Result;
        var newOrder = new Order((long)createdCustomer.ID);
        var createdOrder = orderService.CreateOrder(newOrder).Result;

        // Act
        var order = orderService.GetOrder((long)createdOrder.ID).Result;

        // Assert
        Assert.IsNotNull(order);
    }

    [TestMethod]
    public async void TestGetAllOrders()
    {
        // Arrange - Creates an order to make sure there is one in the system.
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = await customerService.CreateCustomer(newCustomer);
        var newOrder = new Order((long)createdCustomer.ID);
        await orderService.CreateOrder(newOrder);

        // Act
        var allOrders = await orderService.GetAllOrders();

        // Assert
        Assert.IsNotNull(allOrders);
    }

    [TestMethod]
    public async void TestUpdateOrder()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var customerOne = await customerService.CreateCustomer(newCustomer);
        var order = new Order((long)customerOne.ID);
        await orderService.CreateOrder(order);


        // Act
        var customerTwo = await customerService.CreateCustomer(newCustomer);
        var updatedOrder = new Order((long)customerTwo.ID);
        var isOrderUpdated = await orderService.UpdateOrder(updatedOrder);

        // Assert
        Assert.IsTrue(isOrderUpdated);
        Assert.AreEqual(updatedOrder.CustomerID, customerTwo.ID);
    }

    [TestMethod]
    public async void TestDeleteOrder()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = await customerService.CreateCustomer(newCustomer);
        var newOrder = new Order((long)createdCustomer.ID);
        var createdOrder = await orderService.CreateOrder(newOrder);

        // Act
        var isOrderDeleted = await orderService.DeleteOrder((long)createdOrder.ID);

        //Assert
        Assert.IsTrue(isOrderDeleted);
    }

    [TestCleanup]
    public async void Cleanup()
    {
        const string testEmail = "TestEmail@TestEmail.com"; // Email used in the tests

        while (await customerService.GetCustomerByEmail(testEmail) != null)
        {
            var customerToDelete = await customerService.GetCustomerByEmail(testEmail);

            if (customerToDelete == null)
            {
                continue;
            }

            var ordersToDelete = await orderService.GetOrdersByCustomerID(customerToDelete.ID);

            foreach (var order in ordersToDelete)
            {
                await orderService.DeleteOrder(order.ID);
            }

            await customerService.DeleteCustomer(customerToDelete.ID);
        }
    }
}