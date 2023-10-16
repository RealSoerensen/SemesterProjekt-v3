using System.Text.Json.Serialization;

namespace Models;

public class ProductDescription
{
    public long? Id { get; set; }
    public string Description { get; set; }
    public byte[] Image { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public long Stock { get; set; }

    [JsonConstructor]
    public ProductDescription(long id, string description, byte[] image, decimal price, string name, long stock)
    {
        Id = id;
        Description = description;
        Image = image;
        Price = price;
        Name = name;
        Stock = stock;
    }

    public ProductDescription(string description, byte[] image, decimal price, string name, long stock)
    {
        Description = description;
        Image = image;
        Price = price;
        Name = name;
        Stock = stock;
    }
}