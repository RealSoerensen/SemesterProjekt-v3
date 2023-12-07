using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services;

public class OrderlineService
{
    private readonly OrderlineRepository orderlineRepository;

    public OrderlineService()
    {
        var connectionString = DBConnection.GetConnectionString();
        orderlineRepository = new OrderlineRepository(connectionString);
    }

    public async Task CreateOrderline(Orderline orderline)
    {
        try
        {
            await orderlineRepository.Create(orderline);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}