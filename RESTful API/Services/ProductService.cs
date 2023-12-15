using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services;

public class ProductService
{
    private readonly ProductRepository productRepository;

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

    public async Task<bool> TryUpdateProduct(Product product, DateTime originalVersion)
    {
        try
        {
            var updatedRows = await productRepository.UpdateProductIfVersionMatches(product, originalVersion);
            // If no rows are updated, it means the version has changed in the meantime
            return updatedRows > 0;
        }
        catch (Exception e)
        {
            // Log the exception for debugging purposes
            Console.WriteLine(e);

            // In case of any other exception, we consider the update as failed
            return false;
        }
    }

}