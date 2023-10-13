using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.ProductDescriptionDA;

namespace RESTful_API.Services;

public class ProductDescriptionService
{
    private readonly IProductDescriptionDA productDescriptionRepository;

    public ProductDescriptionService()
    {
        var connectionString = DBConnection.GetConnectionString();
        productDescriptionRepository = new ProductDescriptionRepository(connectionString);
    }

    public ProductDescription CreateProductDescription(ProductDescription productDescription)
    {
        try
        {
            return productDescriptionRepository.Create(productDescription);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public ProductDescription GetProductDescriptionById(int id)
    {
        try
        {
            return productDescriptionRepository.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public List<ProductDescription> GetAllProductDescriptions()
    {
        try
        {
            return productDescriptionRepository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool UpdateProductDescription(ProductDescription productDescription)
    {
        try
        {
            return productDescriptionRepository.Update(productDescription);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool DeleteProductDescription(long id)
    {
        try
        {
            return productDescriptionRepository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}