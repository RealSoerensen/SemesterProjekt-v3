using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.ProductDA;

namespace RESTful_API.Services;

public class ProductService
{
    private readonly IProductDA productRepository;

    public ProductService()
    {
        var connectionString = DBConnection.GetConnectionString();
        productRepository = new ProductRepository(connectionString);
    }

    public async Task<Product> CreateProduct(Product product)
    {
        try
        {
            return await productRepository.Create(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<Product> GetProductByID(long id)
    {
        try
        {
            return await productRepository.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<List<Product>> GetAllProducts()
    {
        try
        {
            return await productRepository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        try
        {
            return await productRepository.Update(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> DeleteProduct(long id)
    {
        try
        {
            var productToDelete = await GetProductByID(id);
            productToDelete.Inactive = true;
            return productToDelete.Inactive;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<List<Product>> GetProductsByCategory(int category)
    {
        try
        {
            return await productRepository.GetProductsByCategory(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}