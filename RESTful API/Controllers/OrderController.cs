using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderDB orderDA;

    public OrderController(OrderDB orderDA)
    {
        this.orderDA = orderDA;
    }

    // GET: api/<OrderController>
    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = orderDA.GetAll();
        if (orders.Count == 0)
        {
            return NotFound("No orders found");
        }

        return Ok(orders);
    }

    // GET api/<OrderController>/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var order = orderDA.Get(id);
        if (order == null)
        {
            return NotFound($"Order with id {id} was not found");
        }

        return Ok(order);
    }

    // POST api/<OrderController>
    [HttpPost]
    public IActionResult Create([FromBody] Order order)
    {
        var createdOrder = orderDA.Create(order);
        if (createdOrder == null)
        {
            return BadRequest("Order creation failed");
        }

        return Ok(createdOrder);
    }

    // PUT api/<OrderController>/5
    [HttpPut]
    public IActionResult Update([FromBody] Order order)
    {
        var updatedOrder = orderDA.Update(order);
        if (!updatedOrder)
        {
            return BadRequest("Order update failed");
        }

        return Ok(updatedOrder);
    }

    // DELETE api/<OrderController>/5
    [HttpDelete]
    public IActionResult Delete([FromBody] Order order)
    {
        var deletedOrder = orderDA.Delete(order);
        if (!deletedOrder)
        {
            return BadRequest("Order deletion failed");
        }

        return Ok(deletedOrder);
    }
}