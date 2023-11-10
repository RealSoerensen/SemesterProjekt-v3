using Client.DAL;
using Models;

namespace Client.Controllers;

internal class OrderController
{
    private readonly OrderDA _orderDA = new();

    public Order? Get(int id)
    {
        return _orderDA.Get(id);
    }

    public List<Order>? GetAll()
    {
        return _orderDA.GetAll();
    }

    public Order? Create(Order order)
    {
        return _orderDA.Create(order);
    }

    public bool Delete(long id)
    {
        return _orderDA.Delete(id);
    }

    public bool Update(Order order)
    {
        return _orderDA.Update(order);
    }
};