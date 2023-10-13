namespace Models;

public class Order
{
    public DateTime DateTime { get; set; } = DateTime.Now;
    public long? Id { get; set; }
    public long CustomerID { get; set; }
    public double TotalPrice { get; set; }
    public int Discount { get; set; }

    public Order(long id, long customerID, double totalPrice, int discount)
    {
        Id = id;
        CustomerID = customerID;
        TotalPrice = totalPrice;
        Discount = discount;
    }

    public Order(long customerID, double totalPrice, int discount)
    {
        CustomerID = customerID;
        TotalPrice = totalPrice;
        Discount = discount;
    }
}