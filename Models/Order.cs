namespace Models;

public class Order
{
    public DateTime DateTime { get; set; } = DateTime.Now;
    public long? Id { get; set; }
    public Customer Customer { get; set; }
    public double TotalPrice { get; set; }
    public int Discount { get; set; }

    public Order(long id, Customer customer, double totalPrice, int discount)
    {
        Id = id;
        Customer = customer;
        TotalPrice = totalPrice;
        Discount = discount;
    }

    public Order(Customer customer, double totalPrice, int discount)
    {
        Customer = customer;
        TotalPrice = totalPrice;
        Discount = discount;
    }
}