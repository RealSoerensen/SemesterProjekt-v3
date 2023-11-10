using Models;
using RESTful_API.Services;

namespace ApiTests;

[TestClass]
public class CustomerTests
{
    private readonly CustomerService customerService = new();

    [TestMethod]
    public void CreateCustomer_ReturnsCustomer()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");

        // Act
        var createdCustomer = customerService.CreateCustomer(newCustomer);

        // Assert
        Assert.IsNotNull(createdCustomer);
        Assert.AreEqual(newCustomer.FirstName, createdCustomer.FirstName);
        Assert.AreEqual(newCustomer.LastName, createdCustomer.LastName);
        Assert.AreEqual(newCustomer.Email, createdCustomer.Email);
        Assert.AreEqual(newCustomer.PhoneNo, createdCustomer.PhoneNo);
        Assert.AreEqual(newCustomer.Password, createdCustomer.Password);
        Assert.IsNotNull(createdCustomer.ID);
        Assert.AreEqual(newCustomer.AddressID, createdCustomer.AddressID);
    }

    [TestMethod]
    public void GetCustomer_ReturnsCustomer()
    {
        // Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");

        // Act
        var createdCustomer = customerService.CreateCustomer(newCustomer);
        Assert.IsNotNull(createdCustomer);
        Assert.IsNotNull(createdCustomer.ID);
        var customer = customerService.GetCustomer((long)createdCustomer.ID);
        Assert.IsNotNull(customer);

        //Assert
        Assert.AreEqual(createdCustomer.ID, customer.ID);
    }

    [TestMethod]
    public void GetAllCustomers_ReturnsCustomers()
    {
        //Arrange - All customers already exists.

        //Act
        var allCustomers = customerService.GetAllCustomers();

        //Assert
        Assert.IsNotNull(allCustomers);
    }

    [TestMethod]
    public void UpdateCustomer_ReturnsTrue()
    {
        //Arrange
        var customer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(customer);
        var updatedFirstName = "UpdatedTestFirstName";
        var updatedLastName = "UpdatedTestLastName";

        //Act
        createdCustomer.FirstName = updatedFirstName;
        createdCustomer.LastName = updatedLastName;
        var isCustomerUpdated = customerService.UpdateCustomer(createdCustomer);

        //Assert
        Assert.IsTrue(isCustomerUpdated);
        Assert.IsTrue(createdCustomer.FirstName.Equals(updatedFirstName));
        Assert.IsTrue(createdCustomer.LastName.Equals(updatedLastName));
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsTrue()
    {
        //Arrange
        var newCustomer = new Customer("TestFirstName", "TestLastName", "TestEmail@TestEmail.com", "TestPassword", "00000000");
        var createdCustomer = customerService.CreateCustomer(newCustomer);

        //Act
        var successfullyDeleted = customerService.DeleteCustomer((long)createdCustomer.ID);

        //Assert
        Assert.IsTrue(successfullyDeleted);
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsFalse()
    {
        //Assert that if we try to delete a customer who does not exist we return false.
        var successfullyDeleted = customerService.DeleteCustomer(-1);
        Assert.IsFalse(successfullyDeleted);
    }
}