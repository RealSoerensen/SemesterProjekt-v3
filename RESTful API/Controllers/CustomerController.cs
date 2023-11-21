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
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        try
        {
            var createdCustomer = await customerService.CreateCustomer(customer);
            return Ok(createdCustomer);
        }
        catch (Exception)
        {
            return BadRequest("Customer creation failed - DB ERROR");
        }
    }

    // GET api/<CustomerController>/email
    [HttpGet("{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        Customer? customer;
        try
        {
            customer = await customerService.GetCustomerByEmail(email);
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

    [HttpGet("GetByID/{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        Customer? customer;
        try
        {
            customer = await customerService.GetCustomer(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the customer.");
        }

        if (customer == null)
        {
            return NotFound($"Customer {id} was not found");
        }

        return Ok(customer);
    }

    // GET api/<CustomerController>/emailExist
    [HttpGet("CheckEmailExists/{email}")]
    public async Task<IActionResult> CheckEmailExists(string email)
    {
        bool emailExists;
        try
        {
            emailExists = await customerService.CheckEmailExists(email);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while checking the email.");
        }
        return Ok(emailExists);
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public async Task<IActionResult> GetAll()
    {
        List<Customer> customers;
        try
        {
            customers = await customerService.GetAllCustomers();
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
    public async Task<IActionResult> Update([FromBody] Customer customer)
    {
        bool isUpdated;
        try
        {
            isUpdated = await customerService.UpdateCustomer(customer);
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
    public async Task<IActionResult> Delete(long id)
    {
        bool isDeleted;
        try
        {
            isDeleted = await customerService.DeleteCustomer(id);
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