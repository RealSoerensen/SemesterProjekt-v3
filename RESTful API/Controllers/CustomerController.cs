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
        var createdCustomer = customerDA.Create(customer);

        return Ok(createdCustomer);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var customer = customerDA.Get(id);
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
        var customers = customerDA.GetAll();
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
        var updatedCustomer = customerDA.Update(customer);
        if (!updatedCustomer)
        {
            return BadRequest("Customer update failed");
        }

        return Ok(customer);
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete]
    public IActionResult Delete([FromBody] Customer customer)
    {
        var deletedCustomer = customerDA.Delete(customer);
        if (!deletedCustomer)
        {
            return BadRequest("Customer deletion failed");
        }

        return Ok(customer);
    }
}