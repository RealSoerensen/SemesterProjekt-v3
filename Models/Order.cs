namespace Models;

public class Order
{
    public long ID { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.Now;
    public long CustomerID { get; set; }
    public Status Status { get; set; } = Status.Pending;

    public Order(DateTime date, long id, long customerID, Status status)
    {
        ID = id;
        Date = date;
        CustomerID = customerID;
        Status = status;
    }

    public Order(long customerID)
    {
        CustomerID = customerID;
    }

    public Order()
    {

    }
}