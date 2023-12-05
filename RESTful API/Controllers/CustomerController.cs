using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService = new();

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
}