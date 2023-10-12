namespace Models
{
    public class ProductDescription
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public ProductDescription(int id, string description, string image, double price, string name, int stock)
        {
            Id = id;
            Description = description;
            Image = image;
            Price = price;
            Name = name;
            Stock = stock;
        }

        public ProductDescription(string description, string image, double price, string name, int stock)
        {
            Description = description;
            Image = image;
            Price = price;
            Name = name;
            Stock = stock;
        }
    }
}