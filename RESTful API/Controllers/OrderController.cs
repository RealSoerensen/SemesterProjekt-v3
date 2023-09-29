using API.DAL.OrderDA;
using Microsoft.AspNetCore.Mvc;
using API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrder _orderDB;

    public OrderController(IOrder orderDB)
    {
        _orderDB = orderDB;
    }

    // GET: api/<OrderController>
    [HttpGet]
    public List<Order> GetAll()
    {
        return _orderDB.GetAll();
    }

    // GET api/<OrderController>/5
    [HttpGet("{id:int}")]
    public Order? Get(int id)
    {
        return _orderDB.Get(id);
    }

    // POST api/<OrderController>
    [HttpPost]
    public Order? Create([FromBody] Order order)
    {
        return _orderDB.Create(order);
    }

    // PUT api/<OrderController>/5
    [HttpPut]
    public bool Update([FromBody] Order order)
    {
        return _orderDB.Update(order);
    }

    // DELETE api/<OrderController>/5
    [HttpDelete]
    public bool Delete(Order order)
    {
        return _orderDB.Delete(order);
    }
}