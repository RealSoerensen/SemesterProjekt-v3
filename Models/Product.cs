using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

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
    }
}