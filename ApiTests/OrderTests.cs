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
        throw new NotImplementedException();
    }

    [TestMethod]
    public void TestGetOrder()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void TestGetAllOrders()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void TestUpdateOrder()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void TestDeleteOrder()
    {
        throw new NotImplementedException();
    }
}