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

    public async Task<Orderline> CreateOrderline(Orderline orderline)
    {
        try
        {
            return await orderlineRepository.Create(orderline);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<List<Orderline>> GetOrderlineById(long id)
    {
        try
        {
            return await orderlineRepository.GetOrderlines(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<List<Orderline>> GetAllOrderlines()
    {
        try
        {
            return await orderlineRepository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> UpdateOrderline(Orderline orderline)
    {
        try
        {
            return await orderlineRepository.Update(orderline);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> DeleteOrderline(long id)
    {
        try
        {
            return await orderlineRepository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}