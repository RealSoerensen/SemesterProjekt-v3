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

    public Product CreateProduct(Product product)
    {
        try
        {
            return productRepository.Create(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public Product GetProductByID(long id)
    {
        try
        {
            return productRepository.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            return productRepository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool UpdateProduct(Product product)
    {
        try
        {
            return productRepository.Update(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool DeleteProduct(long id)
    {
        try
        {
            var productToDelete = GetProductByID(id);
            productToDelete.Inactive = true;
            return productToDelete.Inactive;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public List<Product> GetProductsByCategory(int category)
    {
        try
        {
            return productRepository.GetProductsByCategory(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}