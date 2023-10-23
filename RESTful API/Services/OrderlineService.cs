using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.OrderlineDA;

namespace RESTful_API.Services;

public class OrderlineService
{
    private readonly IOrderlineDA orderlineRepository;

    public OrderlineService()
    {
        var connectionString = DBConnection.GetConnectionString();
        orderlineRepository = new OrderlineRepository(connectionString);
    }

    public Orderline CreateOrderline(Orderline orderline)
    {
        try
        {
            return orderlineRepository.Create(orderline);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public List<Orderline> GetOrderlineById(long id)
    {
        try
        {
            return orderlineRepository.GetOrderlines(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public List<Orderline> GetAllOrderlines()
    {
        try
        {
            return orderlineRepository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool UpdateOrderline(Orderline orderline)
    {
        try
        {
            return orderlineRepository.Update(orderline);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool DeleteOrderline(long id)
    {
        try
        {
            return orderlineRepository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}