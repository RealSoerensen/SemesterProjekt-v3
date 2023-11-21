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

    public async Task<Order> CreateOrder(Order order)
    {
        try
        {
            return await _orderDB.Create(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Order> GetOrder(long id)
    {
        try
        {
            return await _orderDB.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Order>> GetAllOrders()
    {
        try
        {
            return await _orderDB.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        try
        {
            return await _orderDB.Update(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteOrder(long id)
    {
        try
        {
            return await _orderDB.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Order>> GetOrdersByCustomerID(long id)
    {
        try
        {
            return await _orderDB.GetOrdersByCustomerID(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}