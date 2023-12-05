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