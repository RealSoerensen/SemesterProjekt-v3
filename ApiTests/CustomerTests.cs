using API.Controllers;
using API.DAL.CustomerDA;
using API.Models;

namespace ApiTests;

[TestClass]
public class CustomerTests
{
    private readonly CustomerController controller = new(CustomerContainer.Instance);

    [TestMethod]
    public void GetAllCustomers_ReturnsListOfCustomers()
    {
        // Arrange
        Customer customer = new(1, "Te", "", "", "", "");
        controller.Create(customer);

        // Act
        var result = controller.GetAll();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(List<Customer>));
    }

    [TestMethod]
    public void GetCustomer_ReturnsCustomer()
    {
        // Arrange
        const int customerId = 1; // Replace with a valid customer ID
        Customer customer = new(customerId, "Te", "", "", "", "");
        controller.Create(customer);

        // Act
        var result = controller.Get(customerId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Customer));
        Assert.AreEqual(customerId, result.Id);
    }

    [TestMethod]
    public void CreateCustomer_ValidCustomer_ReturnsCustomer()
    {
        // Arrange
        Customer newCustomer = new(1, "Te", "", "", "", "");

        // Act
        var result = controller.Create(newCustomer);

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void UpdateCustomer_ValidCustomer_ReturnsBool()
    {
        // Arrange
        Customer oldCustomer = new(1, "Te", "", "", "", "");
        controller.Create(oldCustomer);

        Customer updatedCustomer = new(1, "Et", "", "", "", "");

        // Act
        var result = controller.Update(updatedCustomer);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsNoContent()
    {
        // Arrange
        const int customerIdToDelete = 1; // Replace with a valid customer ID
        Customer customer = new(customerIdToDelete, "Te", "", "", "", "");
        controller.Create(customer);

        // Act
        var customerToDelete = controller.Get(customerIdToDelete);
        Assert.IsNotNull(customerToDelete);
        var result = controller.Delete(customerToDelete);

        // Assert
        Assert.IsTrue(result);
    }
}