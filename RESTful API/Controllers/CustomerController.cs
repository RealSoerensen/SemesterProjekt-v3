using API.DAL.CustomerDA;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using RESTful_API.DAL.AddressDA;
using RESTful_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService customerService;

    public CustomerController()
    {
        customerService = new(new CustomerDB(), new AddressDB());
    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult Create([FromBody] Customer customer)
    {
        Customer? createdCustomer = customerService.Create(customer);
        if (createdCustomer == null)
        {
            return BadRequest("Customer creation failed");
        }

        return Ok(createdCustomer);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id:int}")]
    public Customer? Get(int id)
    {
        return customerService.Get(id);
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public List<Customer> GetAll()
    {
        return customerService.GetAll();
    }

    // PUT api/<CustomerController>
    [HttpPut]
    public bool Update([FromBody] Customer customer)
    {
        return customerService.Update(customer);
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete]
    public bool Delete([FromBody] Customer customer)
    {
        return customerService.Delete(customer);
    }
}