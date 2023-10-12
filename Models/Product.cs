namespace Models
{
    public class Product
    {
        public long? ProductSN { get; set; }
        public ProductDescription ProductDescriptionID { get; set; }

        public Product(long productSN, ProductDescription productDescriptionID)
        {
            ProductSN = productSN;
            ProductDescriptionID = productDescriptionID;
        }

        public Product(ProductDescription productDescriptionID)
        {
            ProductDescriptionID = productDescriptionID;
        }
    }
}