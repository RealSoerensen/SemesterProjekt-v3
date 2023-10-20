using System.Text.Json.Serialization;

namespace Models;

public class Order
{
    public long? Id { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string CustomerEmail { get; set; }
    public int Discount { get; set; }

    [JsonConstructor]
    public Order(DateTime date, long id, string customerEmail, int discount)
    {
        Id = id;
        DateTime = date;
        CustomerEmail = customerEmail;
        Discount = discount;
    }

    public Order(string customerEmail, int discount)
    {
        CustomerEmail = customerEmail;
        Discount = discount;
    }
}