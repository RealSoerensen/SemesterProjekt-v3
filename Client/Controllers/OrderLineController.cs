using Client.DAL;
using Models;

namespace Client.Controllers;

internal class OrderlineController
{
    private readonly OrderlineDA _orderlineDA = new();

    public List<Orderline> Get(long id)
    {
        return _orderlineDA.Get(id);
    }

    public List<Orderline> GetAll()
    {
        return _orderlineDA.GetAll();
    }

    public Orderline? Create(Orderline orderline)
    {
        return _orderlineDA.Create(orderline);
    }

    public bool Delete(long id)
    {
        return _orderlineDA.Delete(id);
    }

    public bool Update(Orderline orderline)
    {
        return _orderlineDA.Update(orderline);
    }
}