using Models;

namespace RESTful_API.Repositories.OrderlineDA;

public interface IOrderlineDA : ICRUD<Orderline>
{
    List<Orderline> GetOrderlines(long id);
}