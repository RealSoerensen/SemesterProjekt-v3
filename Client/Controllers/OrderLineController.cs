using Client.DAL;
using Models;

namespace Client.Controllers;

internal class OrderlineController
{
    private readonly OrderlineDA _orderlineDA = new();

    public Task<List<Orderline>?> Get(long id)
    {
        return _orderlineDA.GetOrderlines(id);
    }

    public Task<List<Orderline>> GetAll()
    {
        return _orderlineDA.GetAll();
    }

    public Task<Orderline?> Create(Orderline orderline)
    {
        return _orderlineDA.Create(orderline);
    }

    public Task<bool> Delete(long id)
    {
        return _orderlineDA.Delete(id);
    }

    public Task<bool> Update(Orderline orderline)
    {
        return _orderlineDA.Update(orderline);
    }
}