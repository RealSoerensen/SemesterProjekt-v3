using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService = new();

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
        Customer? customer;
        try
        {
            customer = customerService.GetCustomerByEmail(email);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the customer.");
        }

        if (customer == null)
        {
            return NotFound($"Customer with email {email} was not found");
        }

        return Ok(customer);
    }

    // GET api/<CustomerController>/emailExist
    [HttpGet("CheckEmailExists/{email}")]
    public IActionResult CheckEmailExists(string email)
    {
        bool emailExists;
        try
        {
            emailExists = customerService.CheckEmailExists(email);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while checking the email.");
        }
        return Ok(emailExists);
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public IActionResult GetAll()
    {
        List<Customer> customers;
        try
        {
            customers = customerService.GetAllCustomers();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching customers.");
        }

        if (customers.Count == 0)
        {
            return NotFound("No customers found");
        }

        return Ok(customers);
    }

    // PUT api/<CustomerController>
    [HttpPut]
    public IActionResult Update([FromBody] Customer customer)
    {
        bool isUpdated;
        try
        {
            isUpdated = customerService.UpdateCustomer(customer);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the customer.");
        }

        if (!isUpdated)
        {
            return BadRequest("Customer unable to update");
        }

        return Ok();
    }

    // DELETE api/<CustomerController>/email
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        bool isDeleted;
        try
        {
            isDeleted = customerService.DeleteCustomer(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the customer.");
        }

        if (!isDeleted)
        {
            return BadRequest("Customer deletion failed");
        }

        return Ok();
    }
}