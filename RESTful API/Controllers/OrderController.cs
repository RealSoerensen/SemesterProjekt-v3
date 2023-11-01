using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json.Linq;
using RESTful_API.Repositories.OrderDA;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly OrderlineService _orderlineService;

    public OrderController()
    {
        _orderService = new OrderService();
        _orderlineService = new OrderlineService();
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
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
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
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
        }

        if (order == null)
        {
            return NotFound();
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
            return Ok(createdOrder != null);
        }
        catch (Exception)
        {
            return BadRequest("Order creation failed - DB ERROR");
        }
    }

    [HttpPost]
    [Route("CreateWithID/{customerID:int}")]
    public IActionResult CreateWithID(int customerID, [FromBody] Orderline[] orderlines)
    {
        try
        {
            var order = new Order(customerID);
            try
            {
                order = _orderService.CreateOrder(order);
            }
            catch (Exception)
            {
                return BadRequest("Order creation failed - DB ERROR");
            }

            if (order.Id == null) return BadRequest("Order creation failed - DB ERROR");

            foreach (var orderline in orderlines)
            {
                orderline.OrderID = (long)order.Id;
                try
                {
                    _orderlineService.CreateOrderline(orderline);
                }
                catch (Exception)
                {
                    return BadRequest("Orderline creation failed - DB ERROR");
                }
            }
            return Ok(true);
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
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted;
        try
        {
            isDeleted = _orderService.DeleteOrder(id);
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
    public IActionResult GetOrdersByCustomerID(long id)
    {
        List<Order> orders;
        try
        {
            orders = _orderService.GetOrdersByCustomerID(id);
        }
        catch (Exception)
        {
            return BadRequest("Order retrieval failed - DB ERROR");
        }

        if (orders == null)
        {
            return NotFound("No orders found");
        }

        return Ok(orders);
    }
}