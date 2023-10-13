using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.OrderDA;

namespace RESTful_API.Services;

public class OrderService
{
    private readonly IOrderDA _orderDB;

    public OrderService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _orderDB = new OrderRespository(connectionString);
    }

    public Order CreateOrder(Order order)
    {
        try
        {
            return _orderDB.Create(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Order GetOrder(long id)
    {
        try
        {
            return _orderDB.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Order> GetAllOrders()
    {
        try
        {
            return _orderDB.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateOrder(Order order)
    {
        try
        {
            return _orderDB.Update(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteOrder(long id)
    {
        try
        {
            return _orderDB.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}