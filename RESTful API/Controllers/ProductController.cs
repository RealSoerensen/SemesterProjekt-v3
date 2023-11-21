﻿using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAll()
    {
        List<Product> products;
        try
        {
            products = await productService.GetAllProducts();
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

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        bool isDeleted;
        try
        {
            isDeleted = await productService.DeleteProduct(id);
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

    [HttpGet("category/{categoryId:int}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        List<Product> products;
        try
        {
            products = await productService.GetProductsByCategory(categoryId);
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
}