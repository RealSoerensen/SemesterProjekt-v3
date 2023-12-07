using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderlineController : ControllerBase
{
    private readonly OrderlineService orderlineService = new();

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
}