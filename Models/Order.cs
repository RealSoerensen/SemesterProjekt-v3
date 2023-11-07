using System.Text.Json.Serialization;

namespace Models;

public class Order
{
    public long? ID { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public long CustomerID { get; set; }

    public Order(DateTime date, long id, long customerID)
    {
        ID = id;
        Date = date;
        CustomerID = customerID;
    }

    public Order(long customerID)
    {
        CustomerID = customerID;
    }
}