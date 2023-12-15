using Newtonsoft.Json;

namespace Models;

public class Order
{
    public long ID { get; set; }
    public DateTime Date { get; init; } = DateTime.Now;
    public long CustomerID { get; init; }
    public Status Status { get; init; } = Status.Pending;

    public Order(DateTime date, long id, long customerID, Status status)
    {
        ID = id;
        Date = date;
        CustomerID = customerID;
        Status = status;
    }

    [JsonConstructor]
    public Order(long customerID)
    {
        CustomerID = customerID;
    }
}