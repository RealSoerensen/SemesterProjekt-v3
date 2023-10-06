namespace Models;

public class Order
{
    public long Id { get; set; }
    public long CustomerId { get; set; }

    public Order()
    {
    }

    public Order(long id, long customerId)
    {
        Id = id;
        CustomerId = customerId;
    }
}