namespace Models;

public class Order
{
    public DateTime DateTime { get; set; } = DateTime.Now;
    public long? Id { get; set; }
    public string CustomerEmail { get; set; }
    public double TotalPrice { get; set; }
    public int Discount { get; set; }

    public Order(long id, string customerEmail, double totalPrice, int discount)
    {
        Id = id;
        CustomerEmail = customerEmail;
        TotalPrice = totalPrice;
        Discount = discount;
    }

    public Order(string customerEmail, double totalPrice, int discount)
    {
        CustomerEmail = customerEmail;
        TotalPrice = totalPrice;
        Discount = discount;
    }
}