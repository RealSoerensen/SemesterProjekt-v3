using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.CustomerDA;
using RESTful_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService;

    public CustomerController()
    {
        DBConnection dBConnection = new();
        var connectionString = dBConnection.ConnectionString ?? throw new Exception("Unable to get Connection String from secrets");
        customerService = new CustomerService(new CustomerDB(connectionString));
    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult Create([FromBody] Customer customer)
    {
        try
        {
            var createdCustomer = customerService.Create(customer);
            return Ok(createdCustomer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return BadRequest("Customer creation failed - DB ERROR");
        }
    }

    // GET api/<CustomerController>/5
    [HttpGet("{email}")]
    public IActionResult Get(string email)
    {
        Customer? customer = customerService.Get(email);

        if (customer == null)
        {
            return NotFound($"Customer with email {email} was not found");
        }

        return Ok(customer);
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public IActionResult GetAll()
    {
        List<Customer> customers = customerService.GetAll();
        
        if (customers == null)
        {
            return NotFound("No customers found");
        }

        return Ok(customers);
    }

    // PUT api/<CustomerController>
    [HttpPut]
    public IActionResult Update([FromBody] Customer customer)
    {
        bool isUpdated = customerService.Update(customer);

        if (!isUpdated)
        {
            return BadRequest("Customer unable to update");
        }

        return Ok();
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete]
    public IActionResult Delete([FromBody] Customer customer)
    {
        bool isDeleted = customerService.Delete(customer);

        if (!isDeleted)
        {
            return BadRequest("Customer deletion failed");
        }

        return Ok();
    }
}