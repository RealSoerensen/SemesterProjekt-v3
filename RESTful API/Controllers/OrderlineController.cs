using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderlineController : ControllerBase
{
    private readonly OrderlineService orderlineService;

    public OrderlineController()
    {
        orderlineService = new OrderlineService();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Orderline orderline)
    {
        try
        {
            var createdOrderline = orderlineService.CreateOrderline(orderline);
            return Ok(createdOrderline);
        }
        catch (Exception)
        {
            return BadRequest("Orderline creation failed - DB ERROR");
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        Orderline orderline;
        try
        {
            orderline = orderlineService.GetOrderlineById(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the orderline.");
        }

        if (orderline == null)
        {
            return NotFound($"Orderline with ID {id} was not found");
        }

        return Ok(orderline);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Orderline> orderlines;
        try
        {
            orderlines = orderlineService.GetAllOrderlines();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching orderlines.");
        }

        if (orderlines.Count == 0)
        {
            return NotFound("No orderlines found");
        }

        return Ok(orderlines);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Orderline orderline)
    {
        bool isUpdated;
        try
        {
            isUpdated = orderlineService.UpdateOrderline(orderline);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the orderline.");
        }

        if (!isUpdated)
        {
            return BadRequest("Orderline unable to update");
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted;
        try
        {
            isDeleted = orderlineService.DeleteOrderline(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the orderline.");
        }

        if (!isDeleted)
        {
            return BadRequest("Orderline deletion failed");
        }

        return Ok();
    }
}