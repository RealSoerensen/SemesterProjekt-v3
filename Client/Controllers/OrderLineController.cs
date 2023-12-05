using Client.DAL;
using Models;

namespace Client.Controllers;

internal class OrderlineController
{
    private readonly OrderlineDA _orderlineDA = new();

    public Task<List<Orderline>> GetAll()
    {
        return _orderlineDA.GetAll();
    }
}