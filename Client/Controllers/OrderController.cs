using Client.DAL;
using Models;

namespace Client.Controllers;

internal class OrderController
{
    private readonly OrderDA _orderDA = new();

    public Task<List<Order>> GetAll()
    {
        return _orderDA.GetAll();
    }
}