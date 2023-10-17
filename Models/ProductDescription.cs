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
    public string Brand { get; set; }

    ProductDescription()
    {
    }
}