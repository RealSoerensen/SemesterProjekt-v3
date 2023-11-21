using Client.DAL;
using Models;

namespace Client.Controllers;

internal class OrderController
{
    private readonly OrderDA _orderDA = new();

    public Task<Order?> Get(long id)
    {
        return _orderDA.Get(id);
    }

    public Task<List<Order>> GetAll()
    {
        return _orderDA.GetAll();
    }

    public Task<Order?> Create(Order order)
    {
        return _orderDA.Create(order);
    }

    public Task<bool> Delete(long id)
    {
        return _orderDA.Delete(id);
    }

    public Task<bool> Update(Order order)
    {
        return _orderDA.Update(order);
    }
};