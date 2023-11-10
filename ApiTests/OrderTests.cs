using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Controllers;
using RESTful_API.Repositories;
using RESTful_API.Repositories.OrderDA;
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
        var createdCustomer = customerService.CreateCustomer(newCustomer);
        var newOrder = new Order((long)createdCustomer.ID);

        // Act
        var createdOrder = orderService.CreateOrder(newOrder);

        // Assert
        Assert.IsNotNull(createdOrder);
    }

    [TestMethod]
    public void TestGetOrder()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(newCustomer);
        var newOrder = new Order((long)createdCustomer.ID);
        var createdOrder = orderService.CreateOrder(newOrder);

        // Act
        var order = orderService.GetOrder((long)createdOrder.ID);

        // Assert
        Assert.IsNotNull(createdOrder);
    }

    [TestMethod]
    public void TestGetAllOrders()
    {
        // Arrange - Creates an order to make sure there is one in the system.
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(newCustomer);
        var newOrder = new Order((long)createdCustomer.ID);
        orderService.CreateOrder(newOrder);

        // Act
        var allOrders = orderService.GetAllOrders();

        // Assert
        Assert.IsNotNull(allOrders);
    }

    [TestMethod]
    public void TestUpdateOrder()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var customerOne = customerService.CreateCustomer(newCustomer);
        var order = new Order((long)customerOne.ID);
        orderService.CreateOrder(order);


        // Act
        var customerTwo = customerService.CreateCustomer(newCustomer);
        var updatedOrder = new Order((long)customerTwo.ID);
        var isOrderUpdated = orderService.UpdateOrder(updatedOrder);

        // Assert
        Assert.IsTrue(isOrderUpdated);
        Assert.AreEqual(updatedOrder.CustomerID, customerTwo.ID);
    }

    [TestMethod]
    public void TestDeleteOrder()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(newCustomer);
        var newOrder = new Order((long)createdCustomer.ID);
        var createdOrder = orderService.CreateOrder(newOrder);

        // Act
        var isOrderDeleted = orderService.DeleteOrder((long)createdOrder.ID);

        //Assert
        Assert.IsTrue(isOrderDeleted);
    }

    [TestCleanup]
    public void Cleanup() {
        var testEmail = "TestEmail@TestEmail.com"; // Email used in the tests

        while (customerService.GetCustomerByEmail(testEmail) != null) {
            var customerToDelete = customerService.GetCustomerByEmail(testEmail);

            var ordersToDelete = orderService.GetOrdersByCustomerID((long)customerToDelete.ID);

            foreach(Order order in ordersToDelete) {
                orderService.DeleteOrder((long)order.ID);
            }

            customerService.DeleteCustomer((long)customerToDelete.ID);
        }
    }
}