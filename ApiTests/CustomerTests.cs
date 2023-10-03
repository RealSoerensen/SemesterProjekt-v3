using API.Controllers;
using API.DAL.CustomerDA;
using API.Models;

namespace ApiTests;

[TestClass]
public class CustomerTests
{
    private readonly CustomerController controller = new(CustomerContainer.Instance);

    
}