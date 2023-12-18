using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService productService = new();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        try
        {
            var createdProduct = await productService.CreateProduct(product);
            return Ok(createdProduct);
        }
        catch (Exception)
        {
            return BadRequest("Product creation failed - DB ERROR");
        }
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        Product product;
        try
        {
            product = await productService.GetProductByID(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the product.");
        }

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Category? category)
    {
        List<Product> products;
        try
        {
            // Check if category is specified in the query
            if (category.HasValue)
            {
                products = await productService.GetProductsByCategory((int)category.Value);
            }
            else
            {
                products = await productService.GetAllProducts();
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching products.");
        }

        if (products.Count == 0)
        {
            return NotFound("No products found");
        }

        return Ok(products);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        bool isUpdated;
        try
        {
            isUpdated = await productService.UpdateProduct(product);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the product.");
        }

        if (!isUpdated)
        {
            return BadRequest("Product unable to update");
        }

        return Ok();
    }
}