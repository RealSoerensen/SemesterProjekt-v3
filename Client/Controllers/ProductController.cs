using Client.DAL;
using Models;
using System.Drawing.Imaging;

namespace Client.Controllers;

internal class ProductController
{
    private readonly ProductDA _productDA = new();

    public Task<Product?> Create(Product product)
    {
        return _productDA.Create(product);
    }

    public Task<List<Product>> GetAll()
    {
        return _productDA.GetAll();
    }

    public Task<Product?> Get(long id)
    {
        return _productDA.Get(id);
    }

    public Task<bool> Update(Product product)
    {
        return _productDA.Update(product);
    }

    public static string ConvertImageToBase64(Image? image)
    {
        if (image == null)
        {
            return string.Empty;
        }

        using var ms = new MemoryStream();
        // Assuming the image format is PNG
        image.Save(ms, ImageFormat.Png);
        var imageBytes = ms.ToArray();
        return Convert.ToBase64String(imageBytes);
    }
}