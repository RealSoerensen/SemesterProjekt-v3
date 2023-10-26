using Models;

namespace RESTful_API.Repositories.OrderDA;

public interface IOrderDA : ICRUD<Order>
{
    List<Order> GetOrdersByCustomerID(long id);
}