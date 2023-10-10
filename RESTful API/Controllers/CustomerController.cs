using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerDB customerDA;

    public CustomerController(CustomerDB customerDA)
    {
        this.customerDA = customerDA;
    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult Create([FromBody] Customer customer)
    {
        try
        {
            var createdCustomer = customerDA.Create(customer);
            return Ok(createdCustomer);
        }
        catch (Exception)
        {
            return BadRequest("Customer creation failed - DB ERROR");
        }
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Customer? customer;
        try
        {
            customer = customerDA.Get(id);
        }
        catch (Exception e)
        {
            return BadRequest("Customer retrieval failed - DB ERROR\n" + e.StackTrace);
        }

        if (customer == null)
        {
            return NotFound($"Customer with id {id} was not found");
        }

        return Ok(customer);
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public IActionResult GetAll()
    {
        List<Customer> customers;
        try 
        {
            customers = customerDA.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest("Customer retrieval failed - DB ERROR\n" + e.StackTrace);
        }
        
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
        bool isUpdated;
        try
        {
            isUpdated = customerDA.Update(customer);

        }
        catch (Exception e)
        {
            return BadRequest("Customer update failed - DB ERROR\n" + e.StackTrace);
        }

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
        bool isDeleted;
        try
        {
            isDeleted = customerDA.Delete(customer);
        }
        catch (Exception e)
        {
            return BadRequest("Customer deletion failed - DB ERROR\n" + e.StackTrace);
        }

        if (!isDeleted)
        {
            return BadRequest("Customer deletion failed");
        }

        return Ok();
    }
}