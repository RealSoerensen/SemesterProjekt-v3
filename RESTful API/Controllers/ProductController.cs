using Microsoft.AspNetCore.Mvc;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService productService;

    public ProductController()
    {
        productService = new ProductService();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        try
        {
            var createdProduct = productService.CreateProduct(product);
            return Ok(createdProduct);
        }
        catch (Exception)
        {
            return BadRequest("Product creation failed - DB ERROR");
        }
    }

    [HttpGet("{productSN}")]
    public IActionResult Get(long productSN)
    {
        Product product;
        try
        {
            product = productService.GetProductBySN(productSN);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while fetching the product.");
        }

        if (product == null)
        {
            return NotFound($"Product with SN {productSN} was not found");
        }

        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Product> products;
        try
        {
            products = productService.GetAllProducts();
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
    public IActionResult Update([FromBody] Product product)
    {
        bool isUpdated;
        try
        {
            isUpdated = productService.UpdateProduct(product);
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

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted;
        try
        {
            isDeleted = productService.DeleteProduct(id);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the product.");
        }

        if (!isDeleted)
        {
            return BadRequest("Product deletion failed");
        }

        return Ok();
    }
}