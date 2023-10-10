using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Controllers;
using RESTful_API.Repositories;
using RESTful_API.Repositories.OrderDA;

namespace ApiTests;

[TestClass]
public class OrderTests
{
    private readonly OrderController _orderController;

    public OrderTests()
    {
        _orderController = new OrderController();
    }

    [TestMethod]
    public void TestCreateOrder()
    {
        // Arrange
        var order = new Order(1, 1);

        // Act
        var result = _orderController.Create(order);

        // Assert
        Assert.IsNotNull(result); // Check if the result is not null
    }

    [TestMethod]
    public void TestGetOrder()
    {
        // Arrange
        var order = new Order(1, 1);
        _orderController.Create(order);

        // Act
        var result = _orderController.Get(1);
        order = (Order)((OkObjectResult)result).Value!;

        // Assert
        Assert.IsNotNull(order); // Check if the order is not null
        Assert.AreEqual(1, order.Id);
        Assert.AreEqual(1, order.CustomerId);
    }

    [TestMethod]
    public void TestGetAllOrders()
    {
        // Arrange
        var order1 = new Order(1, 1);
        _orderController.Create(order1);
        var order2 = new Order(2, 2);
        _orderController.Create(order2);

        // Act
        var result = _orderController.GetAll();
        var orders = (List<Order>)((OkObjectResult)result).Value!;

        // Assert
        Assert.IsNotNull(orders); // Check if the orders is not null
        Assert.AreEqual(2, orders.Count);
    }

    [TestMethod]
    public void TestUpdateOrder()
    {
        // Arrange
        var order = new Order(1, 1);
        _orderController.Create(order);

        // Act
        order.CustomerId = 2;
        var result = _orderController.Update(order);
        var updated = (bool)((OkObjectResult)result).Value!;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(updated);
    }

    [TestMethod]
    public void TestDeleteOrder()
    {
        // Arrange
        var order = new Order(1, 1);
        _orderController.Create(order);

        // Act
        var result = _orderController.Delete(order);
        var deleted = (bool)((OkObjectResult)result).Value!;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(deleted);
    }
}