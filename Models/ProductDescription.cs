using System.Text.Json.Serialization;

namespace Models;

public class ProductDescription
{
    public long? Id { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public long Stock { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }

    [JsonConstructor]
    public ProductDescription(string description, string image, decimal price, string name, long stock, string brand, string category)
    {
        Description = description;
        Image = image;
        Price = price;
        Name = name;
        Stock = stock;
        Brand = brand;
        Category = category;
    }

    public ProductDescription(long id, string description, string image, decimal price, string name, long stock, string brand, string category)
    {
        Id = id;
        Description = description;
        Image = image;
        Price = price;
        Name = name;
        Stock = stock;
        Brand = brand;
        Category = category;
    }
}