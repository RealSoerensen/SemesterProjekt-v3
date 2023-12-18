using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService = new();

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public async Task<IActionResult> GetAll([FromQuery] long id)
    {
        try
        {
            var customers = await customerService.GetAllCustomers();
            if (id == 0) return Ok(customers);
            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} was not found");
            }
            return Ok(customer);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching customers.");
        }
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