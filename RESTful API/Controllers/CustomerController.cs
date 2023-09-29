using API.DAL.CustomerDA;
using API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomer _customerDB;

    public CustomerController(ICustomer customerDB)
    {
        _customerDB = customerDB;
    }

    // POST api/<CustomerController>
    [HttpPost]
    public Customer? Create([FromBody] Customer customer)
    {
        return _customerDB.Create(customer);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id:int}")]
    public Customer? Get(int id)
    {
        var customer = _customerDB.Get(id);
        return customer;
    }

    // GET: api/<CustomerController>
    [HttpGet] // Get all customers
    public List<Customer> GetAll()
    {
        return _customerDB.GetAll();
    }

    // PUT api/<CustomerController>
    [HttpPut]
    public bool Update([FromBody] Customer customer)
    {
        return _customerDB.Update(customer);
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete]
    public bool Delete(Customer customer)
    {
        var customers = GetAll();
        return (from c in customers where c.Id == customer.Id select _customerDB.Delete(c)).FirstOrDefault();
    }
}