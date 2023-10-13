namespace Models;

public class Orderline
{
    public long? Id { get; set; }
    public long OrderID { get; set; }
    public long ProductID { get; set; }
    public int Quantity { get; set; }

    public Orderline(long id, long orderID, long productID, int quantity)
    {
        Id = id;
        OrderID = orderID;
        ProductID = productID;
        Quantity = quantity;
    }

    public Orderline(long orderID, long productID, int quantity)
    {
        OrderID = orderID;
        ProductID = productID;
        Quantity = quantity;
    }
}