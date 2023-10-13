namespace Models;

public class Product
{
    public long? ProductSN { get; set; }
    public long ProductDescriptionID { get; set; }

    public Product(long productDescriptionID, long productSN)
    {
        ProductSN = productSN;
        ProductDescriptionID = productDescriptionID;
    }

    public Product(long productDescriptionID)
    {
        ProductDescriptionID = productDescriptionID;
    }
}