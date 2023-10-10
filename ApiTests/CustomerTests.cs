using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Controllers;
using RESTful_API.Repositories;
using RESTful_API.Repositories.AddressDA;
using RESTful_API.Repositories.CustomerDA;
using RESTful_API.Services;

namespace ApiTests;

[TestClass]
public class CustomerTests
{
    private readonly CustomerService customerService;

    public CustomerTests()
    {
        customerService = new CustomerService();
    }

    [TestMethod]
    public void CreateCustomer_ReturnsCustomer()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer("John", "Doe", address, "", "", "");

        // Act
        var result = customerService.CreateCustomer(customer);

        // Assert
        Assert.IsNotNull(result); // Check if the result is not null
    }

    [TestMethod]
    public void GetCustomer_ReturnsCustomer()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer("John", "Doe", address, "testt", "", "");
        customerService.CreateCustomer(customer);

        // Act
        customer = customerService.GetCustomerByEmail("testt");

        // Assert
        Assert.IsNotNull(customer); // Check if the customer is not null
        Assert.AreEqual("testt", customer.Email);
        Assert.AreEqual("John", customer.FirstName);
        Assert.AreEqual("Doe", customer.LastName);
        Assert.AreEqual(1, address.Id);
    }

    [TestMethod]
    public void GetAllCustomers_ReturnsCustomers()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer1 = new Customer("John", "Doe", address, "", "", "");
        customerService.CreateCustomer(customer1);

        var customer2 = new Customer("Jane", "Doe", address, "", "", "");
        customerService.CreateCustomer(customer2);

        // Act
        var result = customerService.GetAllCustomers();

        // Assert
        Assert.IsNotNull(result); // Check if the customers is not null
        Assert.IsTrue(result.Count >= 2);
    }

    [TestMethod]
    public void UpdateCustomer_ReturnsTrue()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer("John", "Doe", address, "test", "", "");
        customerService.CreateCustomer(customer);
        var updatedCustomer = new Customer("Jane", "Doe", address, "test", "", "");

        // Act
        customerService.UpdateCustomer(updatedCustomer);
        var customerResult = customerService.GetCustomerByEmail("test");

        // Assert
        Assert.IsNotNull(customerResult); // Check if the customer is not null
        Assert.AreEqual("Jane", customerResult.FirstName);
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsTrue()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer("John", "Doe", address, "", "", "");
        customerService.CreateCustomer(customer);

        // Act
        var result = customerService.DeleteCustomer(customer);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsFalse()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer("John", "Doe", address, "", "", "");

        // Act
        var result = customerService.DeleteCustomer(customer);

        // Assert
        Assert.IsFalse(result);
    }
}