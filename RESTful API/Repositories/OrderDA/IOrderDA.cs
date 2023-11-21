using Models;

namespace RESTful_API.Repositories.OrderDA;

public interface IOrderDA : ICRUD<Order>
{
    Task<List<Order>> GetOrdersByCustomerID(long id);
}