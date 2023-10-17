using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDescriptionController : ControllerBase
{
    private readonly ProductDescriptionService productDescriptionService;

    public ProductDescriptionController()
    {
        productDescriptionService = new ProductDescriptionService();
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductDescription productDescription)
    {
        try
        {
            var createdProductDescription = productDescriptionService.CreateProductDescription(productDescription);
            return Ok(createdProductDescription);
        }
        catch (Exception)
        {
            return BadRequest("ProductDescription creation failed - DB ERROR");
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        ProductDescription productDescription;
        try
        {
            productDescription = productDescriptionService.GetProductDescriptionById(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the product description.");
        }

        if (productDescription == null)
        {
            return NotFound($"ProductDescription with ID {id} was not found");
        }

        return Ok(productDescription);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<ProductDescription> productDescriptions;
        try
        {
            productDescriptions = productDescriptionService.GetAllProductDescriptions();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching product descriptions.");
        }

        if (productDescriptions.Count == 0)
        {
            return NotFound("No product descriptions found");
        }

        return Ok(productDescriptions);
    }

    [HttpPut]
    public IActionResult Update([FromBody] ProductDescription productDescription)
    {
        bool isUpdated;
        try
        {
            isUpdated = productDescriptionService.UpdateProductDescription(productDescription);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the product description.");
        }

        if (!isUpdated)
        {
            return BadRequest("ProductDescription unable to update");
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted;
        try
        {
            isDeleted = productDescriptionService.DeleteProductDescription(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the product description.");
        }

        if (!isDeleted)
        {
            return BadRequest("ProductDescription deletion failed");
        }

        return Ok();
    }
}