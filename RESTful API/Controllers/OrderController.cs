using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService = new();

    // GET: api/<OrderController>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Order> orders;
        try
        {
            orders = await _orderService.GetAllOrders();
        }
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
        }

        return Ok(orders);
    }

    // GET api/<OrderController>/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Order? order;
        try
        {
            order = await _orderService.GetOrder(id);
        }
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
        }

        return Ok(order);
    }

    [HttpPost]
    [Route("CreateWithID/{customerID:int}")]
    public async Task<IActionResult> CreateWithID(int customerID, [FromBody] Orderline[] orderlines)
    {
        try
        {
            var order = new Order(customerID);
            order = await _orderService.CreateOrder(order, orderlines);
            return Ok();
        }
        catch (Exception ex)
        {
            // Consider logging the exception details
            return BadRequest($"Order creation failed: {ex.Message}");
        }
    }

    // PUT api/<OrderController>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Order order)
    {
        bool isUpdated;
        try
        {
            isUpdated = await _orderService.UpdateOrder(order);
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
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool isDeleted;
        try
        {
            isDeleted = await _orderService.DeleteOrder(id);
        }
        catch (Exception)
        {
            return BadRequest("Order deletion failed - DB ERROR");
        }

        if (!isDeleted)
        {
            return BadRequest("Order deletion failed");
        }

        return Ok();
    }

    // GET api/<OrderController>/customer/id
    [HttpGet("customer/{id:int}")]
    public async Task<IActionResult> GetOrdersByCustomerID(long id)
    {
        List<Order> orders;
        try
        {
            orders = await _orderService.GetOrdersByCustomerID(id);
        }
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
        }

        return Ok(orders);
    }
}