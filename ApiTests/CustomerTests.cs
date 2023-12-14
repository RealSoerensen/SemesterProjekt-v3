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
        //Arrange
        var customer = new Customer("TestFirstName", "TestLastName", "TestPhonenumber");

        //Act
        var createdCustomer = customerService.CreateCustomer(customer);

        //Assert
        Assert.IsNotNull(createdCustomer);
    }

    [TestMethod]
    public async Task GetCustomer_ReturnsCustomer()
    {
        // Arrange
        var customer = new Customer("TestFirstName", "TestLastName", "TestPhonenumber");
        var createdCustomer = await customerService.CreateCustomer(customer);

        // Act
        var gettedCustomer = await customerService.GetCustomerByID(createdCustomer.ID);

        // Assert
        Assert.AreEqual(createdCustomer.ID, gettedCustomer.ID);
    }


    [TestMethod]
    public void GetAllCustomers_ReturnsCustomers()
    {
        // Arrange
        var customer = new Customer("TestFirstName", "TestLastName", "TestPhonenumber");
        customerService.CreateCustomer(customer);

        // Act
        var gettedCustomers = customerService.GetAllCustomers();

        // Assert
        Assert.IsTrue(gettedCustomers.Result.Count > 0);
    }

    [TestMethod]
    public async Task UpdateCustomer_ReturnsTrue()
    {
        // Arrange
        var customer = new Customer("TestFirstName", "TestLastName", "TestPhonenumber");
        var createdCustomer = await customerService.CreateCustomer(customer);
        createdCustomer.FirstName = "UpdatedTestFirstName";

        // Act
        var updatedCustomer = await customerService.UpdateCustomer(createdCustomer);

        // Assert
        Assert.IsTrue(updatedCustomer);
    }

    [TestCleanup]
    public async Task CleanupAfterTest()
    {
        List<Customer> allCustomers = await customerService.GetAllCustomers();
        foreach(var customer in allCustomers)
        {
            if (customer.PhoneNo.Equals("TestPhonenumber"))
            {
                customer.FirstName = "";
                customer.LastName = "";
                customer.PhoneNo = "";
                customer.AddressID = null;
            }
        }
    }
}