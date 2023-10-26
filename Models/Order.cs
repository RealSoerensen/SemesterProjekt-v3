using System.Text.Json.Serialization;

namespace Models;

public class Order
{
    public long? Id { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public long CustomerID { get; set; }

    public Order(DateTime date, long id, long customerID)
    {
        Id = id;
        DateTime = date;
        CustomerID = customerID;
    }

    public Order(long customerID)
    {
        CustomerID = customerID;
    }
}