using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Repositories.OrderDA;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController()
    {
        _orderService = new OrderService();
    }

    // GET: api/<OrderController>
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Order> orders;
        try
        {
            orders = _orderService.GetAllOrders();
        }
        catch (Exception ex)
        {
               return BadRequest("Order retrieval failed - DB ERROR\n" + ex.StackTrace);
        }
        
        if (orders == null)
        {
            return NotFound("No orders found");
        }

        return Ok(orders);
    }

    // GET api/<OrderController>/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Order? order;
        try
        {
            order = _orderService.GetOrder(id);
        }
        catch (Exception e)
        {
            return BadRequest("Order retrieval failed - DB ERROR\n" + e.StackTrace);
        }

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
        try
        {
            var createdOrder = _orderService.CreateOrder(order);
            return Ok(createdOrder);
        }
        catch (Exception)
        {
            return BadRequest("Order creation failed - DB ERROR");
        }
    }

    // PUT api/<OrderController>/5
    [HttpPut]
    public IActionResult Update([FromBody] Order order)
    {
        bool isUpdated;
        try
        {
            isUpdated = _orderService.UpdateOrder(order);
        }
        catch (Exception)
        {
            return BadRequest("Order update failed - DB ERROR");
        }
        
        if (!isUpdated)
        {
            return BadRequest("Order update failed");
        }

        return Ok();
    }

    // DELETE api/<OrderController>/5
    [HttpDelete]
    public IActionResult Delete([FromBody] Order order)
    {
        bool isDeleted;
        try
        {
            isDeleted = _orderService.DeleteOrder(order);
        }
        catch (Exception e)
        {
            return BadRequest("Order deletion failed - DB ERROR\n" + e.StackTrace);
        }
        
        if (!isDeleted)
        {
            return BadRequest("Order deletion failed");
        }

        return Ok();
    }
}