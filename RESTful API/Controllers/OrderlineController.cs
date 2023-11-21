using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderlineController : ControllerBase
{
    private readonly OrderlineService orderlineService = new();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Orderline orderline)
    {
        try
        {
            var createdOrderline = await orderlineService.CreateOrderline(orderline);
            return Ok(createdOrderline);
        }
        catch (Exception)
        {
            return BadRequest("Orderline creation failed - DB ERROR");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        List<Orderline> orderlines;
        try
        {
            orderlines = await orderlineService.GetOrderlineById(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the orderline.");
        }

        if (orderlines == null)
        {
            return NotFound($"Orderline with ID {id} was not found");
        }

        return Ok(orderlines);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Orderline> orderlines;
        try
        {
            orderlines = await orderlineService.GetAllOrderlines();
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
    public async Task<IActionResult> Update([FromBody] Orderline orderline)
    {
        bool isUpdated;
        try
        {
            isUpdated = await orderlineService.UpdateOrderline(orderline);
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
    public async Task<IActionResult> Delete(int id)
    {
        bool isDeleted;
        try
        {
            isDeleted = await orderlineService.DeleteOrderline(id);
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