namespace API.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }

    public Order(int id, int customerId)
    {
        Id = id;
        CustomerId = customerId;
    }
}