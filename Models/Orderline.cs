namespace Models;

public class Orderline
{
    public long OrderID { get; set; }
    public long ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtTimeOfOrder { get; set; }

    public Orderline(int quantity, decimal priceAtTimeOfOrder, long productID, long orderID)
    {
        OrderID = orderID;
        ProductID = productID;
        Quantity = quantity;
        PriceAtTimeOfOrder = priceAtTimeOfOrder;
    }
}