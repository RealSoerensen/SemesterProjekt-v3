using Models;

namespace RESTful_API.Repositories.ProductDA;

public interface IProductDA : ICRUD<Product>
{
    List<Product> GetProductsByCategory(int category);
}