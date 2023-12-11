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
    public async Task<IActionResult> GetAll([FromQuery] long customerId)
    {
        try
        {
            var orders = await _orderService.GetAllOrders();
            if (customerId != 0)
            {
                orders = orders.Where(o => o.CustomerID == customerId).ToList();
            }
            return Ok(orders);
        }
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
        }

    }

    [HttpPost]
    [Route("CreateWithID/{customerID:int}")]
    public async Task<IActionResult> CreateWithID(int customerID, [FromBody] Orderline[] orderlines)
    {
        try
        {
            var order = new Order(customerID);
            await _orderService.CreateOrder(order, orderlines);
            return Ok();
        }
        catch (Exception ex)
        {
            // Consider logging the exception details
            return BadRequest($"Order creation failed: {ex.Message}");
        }
    }
}