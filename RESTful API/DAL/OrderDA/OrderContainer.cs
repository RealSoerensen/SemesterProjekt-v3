using API.Models;

namespace API.DAL.OrderDA;

public class OrderContainer : IOrder
{
    private readonly List<Order> _orders;
    private OrderContainer()
    {
        _orders = new List<Order>();
    }

    public static OrderContainer Instance { get; } = new OrderContainer();

    public Order Create(Order obj)
    {
        _orders.Add(obj);
        return obj;
    }

    public bool Delete(Order obj)
    {
        return _orders.Remove(obj);
    }

    public Order? Get(int id)
    {
        return _orders.FirstOrDefault(order => order.Id == id);
    }

    public List<Order> GetAll()
    {
        return _orders;
    }

    public bool Update(Order obj)
    {
        foreach (var order in _orders.Where(order => order.Id == obj.Id))
        {
            _orders.Remove(order);
            _orders.Add(obj);
            return true;
        }
        return false;
    }
}