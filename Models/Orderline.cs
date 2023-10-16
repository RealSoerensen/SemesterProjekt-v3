using System.Text.Json.Serialization;

namespace Models;

public class Orderline
{
    public long OrderID { get; set; }
    public long ProductID { get; set; }
    public int Quantity { get; set; }


    [JsonConstructor]
    public Orderline( int quantity, long productSN, long orderID)
    {
        OrderID = orderID;
        ProductID = productSN;
        Quantity = quantity;
    }
}