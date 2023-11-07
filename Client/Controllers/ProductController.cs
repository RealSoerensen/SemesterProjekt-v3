using Client.DAL;
using Models;

namespace Client.Controllers;

internal class ProductController
{
    private readonly ProductDA _productDA;

    public ProductController()
    {
        _productDA = new ProductDA();
    }

    public Product? Create(Product product)
    {
        return _productDA.Create(product);
    }

    public List<Product>? GetAll()
    {
        return _productDA.GetAll();
    }

    public Product? Get(int id)
    {
        return _productDA.Get(id);
    }

    public bool Delete(int id)
    {
        return _productDA.Delete(id);
    }

    public bool Update(Product product)
    {
        return _productDA.Update(product);
    }
}