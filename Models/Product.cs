using Newtonsoft.Json;
using System.Drawing;

namespace Models;

public class Product
{
    public long? ID { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal NormalPrice { get; set; }
    public string Name { get; set; }
    public long Stock { get; set; }
    public string Brand { get; set; }
    public Category Category { get; set; }
    public bool Inactive { get; set; }

    [JsonConstructor]
    public Product(string description, string image, decimal salePrice, decimal purchasePrice, decimal normalPrice, string name, int stock, string brand, int category)
    {
        Description = description;
        Image = image;
        SalePrice = salePrice;
        PurchasePrice = purchasePrice;
        NormalPrice = normalPrice;
        Name = name;
        Stock = stock;
        Brand = brand;
        Category = (Category)category;
        Inactive = false;
    }

    public Product(long ID, string description, string image, decimal salePrice, decimal purchasePrice, decimal normalPrice, string name, long stock, string brand, int category)
    {
        this.ID = ID;
        Description = description;
        Image = image;
        SalePrice = salePrice;
        PurchasePrice = purchasePrice;
        NormalPrice = normalPrice;
        Name = name;
        Stock = stock;
        Brand = brand;
        Category = (Category)category;
        Inactive = false;
    }

    public Image? ConvertBase64ToImage()
    {
        try
        {
            // Remove the data URI prefix if present (e.g., "data:image/png;base64,")
            if (Image.StartsWith("data:image", StringComparison.OrdinalIgnoreCase))
            {
                var commaIndex = Image.IndexOf(",", StringComparison.Ordinal);
                if (commaIndex != -1)
                {
                    Image = Image[(commaIndex + 1)..];
                }
            }

            var imageBytes = Convert.FromBase64String(Image);

            using var ms = new MemoryStream(imageBytes);
            return System.Drawing.Image.FromStream(ms);
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during the conversion
            Console.WriteLine("Error converting base64 to Bitmap: " + ex.Message);
            return null;
        }
    }
}