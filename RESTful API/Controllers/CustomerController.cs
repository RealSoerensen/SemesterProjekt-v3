using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.CustomerDA;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService;

    public CustomerController()
    {
        customerService = new CustomerService();
    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult Create([FromBody] Customer customer)
    {
        try
        {
            var createdCustomer = customerService.CreateCustomer(customer);
            return Ok(createdCustomer);
        }
        catch (Exception)
        {
            return BadRequest("Customer creation failed - DB ERROR");
        }
    }

    // GET api/<CustomerController>/email
    [HttpGet("{email}")]
    public IActionResult Get(string email)
    {
        try
        {
            Customer? customer = customerService.GetCustomerByEmail(email);

            if (customer == null)
            {
                return NotFound($"Customer with email {email} was not found");
            }

            return Ok(customer);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the customer.");
        }
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public IActionResult GetAll()
    {
        try
        {
            List<Customer>? customers = customerService.GetAllCustomers();

            if (customers == null)
            {
                return NotFound("No customers found");
            }

            return Ok(customers);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching customers.");
        }
    }

    // PUT api/<CustomerController>
    [HttpPut]
    public IActionResult Update([FromBody] Customer customer)
    {
        try
        {
            bool isUpdated = customerService.UpdateCustomer(customer);

            if (!isUpdated)
            {
                return BadRequest("Customer unable to update");
            }

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the customer.");
        }
    }

    // DELETE api/<CustomerController>
    [HttpDelete]
    public IActionResult Delete([FromBody] Customer customer)
    {
        try
        {
            bool isDeleted = customerService.DeleteCustomer(customer);

            if (!isDeleted)
            {
                return BadRequest("Customer deletion failed");
            }

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the customer.");
        }
    }
}
