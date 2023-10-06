using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Controllers;
using RESTful_API.DAL;

namespace ApiTests;

[TestClass]
public class CustomerTests
{
    private readonly CustomerController customerController;
    private readonly AddressController addressController;

    public CustomerTests()
    {
        DBConnection dbConnection = new();
        var connectionString = dbConnection.ConnectionString ?? throw new Exception("Unable to get Connection String from secrets");
        customerController = new CustomerController(new CustomerDB(connectionString));
        addressController = new AddressController(new AddressDB(connectionString));
    }

    [TestMethod]
    public void CreateCustomer_ReturnsCustomer()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer("John", "Doe", 1, "", "", "");

        // Act
        addressController.Create(address);
        var result = customerController.Create(customer);

        // Assert
        Assert.IsNotNull(result); // Check if the result is not null
    }

    [TestMethod]
    public void GetCustomer_ReturnsCustomer()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer = new Customer(1, "John", "Doe", 1, "", "", "");
        addressController.Create(address);
        customerController.Create(customer);

        // Act
        var result = customerController.Get(1);
        customer = (Customer)((OkObjectResult)result).Value!;

        // Assert
        Assert.IsNotNull(customer); // Check if the customer is not null
        Assert.AreEqual(1, customer.Id);
        Assert.AreEqual("John", customer.FirstName);
        Assert.AreEqual("Doe", customer.LastName);
        Assert.AreEqual(1, customer.AddressId);
    }

    [TestMethod]
    public void GetAllCustomers_ReturnsCustomers()
    {
        // Arrange
        var address = new Address("Street", "City", "State", "ZipCode", "");
        var customer1 = new Customer("John", "Doe", 1, "", "", "");
        addressController.Create(address);
        customerController.Create(customer1);

        var customer2 = new Customer("Jane", "Doe", 1, "", "", "");
        customerController.Create(customer2);

        // Act
        var result = customerController.GetAll();
        var customers = (List<Customer>)((OkObjectResult)result).Value!;

        // Assert
        Assert.IsNotNull(customers); // Check if the customers is not null
        Assert.IsTrue(customers.Count >= 2);
    }

    [TestMethod]
    public void UpdateCustomer_ReturnsTrue()
    {
        // Arrange
        var customer = new Customer(1, "John", "Doe", 1, "", "", "");
        customerController.Create(customer);
        var updatedCustomer = new Customer(1, "Jane", "Doe", 1, "", "", "");

        // Act
        customerController.Update(updatedCustomer);
        var customerResult = customerController.Get(1);
        customer = (Customer)((OkObjectResult)customerResult).Value!;

        // Assert
        Assert.AreEqual("Jane", customer.FirstName);
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsTrue()
    {
        // Arrange
        var customer = new Customer("John", "Doe", 1, "", "", "");
        customerController.Create(customer);

        // Act
        var result = customerController.Delete(customer);
        var resultBool = (bool)((BadRequestObjectResult)result).Value!;

        // Assert
        Assert.IsTrue(resultBool);
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsFalse()
    {
        // Arrange
        var customer = new Customer("John", "Doe", 1, "", "", "");

        // Act
        var result = customerController.Delete(customer);
        var resultBool = (bool)((BadRequestObjectResult)result).Value!;

        // Assert
        Assert.IsFalse(resultBool);
    }
}