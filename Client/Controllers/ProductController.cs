using Client.DAL;
using Models;

namespace Client.Controllers;

internal class ProductController
{
    private readonly ProductDA _productDA = new();

    public Product? Create(Product product)
    {
        return _productDA.Create(product);
    }

    public List<Product> GetAll()
    {
        return _productDA.GetAll();
    }

    public Product? Get(long id)
    {
        return _productDA.Get(id);
    }

    public bool Delete(long id)
    {
        return _productDA.Delete(id);
    }

    public bool Update(Product product)
    {
        return _productDA.Update(product);
    }

    public string ConvertImageToBase64(Image image) {
        if (image == null) {
            return String.Empty;
        }
        using (MemoryStream ms = new MemoryStream()) {
            // Assuming the image format is PNG
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
        }
    }
}