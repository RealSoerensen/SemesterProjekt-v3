using Client.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Client.Controllers;

internal class OrderController
{
    private readonly OrderDA _orderDA;

    public OrderController()
    {
        _orderDA = new OrderDA();
    }

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