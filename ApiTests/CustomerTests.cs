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
        throw new NotImplementedException();
    }

    [TestMethod]
    public void GetCustomer_ReturnsCustomer()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void GetAllCustomers_ReturnsCustomers()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void UpdateCustomer_ReturnsTrue()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsTrue()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void DeleteCustomer_ReturnsFalse()
    {
        throw new NotImplementedException();
    }
}