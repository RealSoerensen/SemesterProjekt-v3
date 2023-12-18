using Models;

namespace Client.Models;

public class OrderViewModel
{
    public long OrderID { get; set; }
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfOrderlines { get; set; }
    public int NumberOfProducts { get; set; }
    public decimal PriceOfOrder { get; set; }
    public List<Orderline> Orderlines { get; set; }
}