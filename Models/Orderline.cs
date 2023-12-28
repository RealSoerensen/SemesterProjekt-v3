namespace Models;

public class Orderline
{
    public long OrderID { get; set; }
    public long ProductID { get; init; }
    public int Quantity { get; init; }
    public decimal PriceAtTimeOfOrder { get; init; }

    public Orderline(int quantity, decimal priceAtTimeOfOrder, long productID, long orderID)
    {
        OrderID = orderID;
        ProductID = productID;
        Quantity = quantity;
        PriceAtTimeOfOrder = priceAtTimeOfOrder;
    }

    public Orderline(long productID, int quantity, decimal priceAtTimeOfOrder)
    {
        ProductID = productID;
        Quantity = quantity;
        PriceAtTimeOfOrder = priceAtTimeOfOrder;
    }

    public Orderline() { }
}