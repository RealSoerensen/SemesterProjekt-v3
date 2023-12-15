using Models;
using RESTful_API.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Services;

public class OrderService
{
    private readonly OrderRespository _orderDB;
    private readonly OrderlineService _orderlineService = new();
    private readonly ProductService _productService = new();
    private readonly string connectionString = DBConnection.GetConnectionString();

    public OrderService()
    {
        _orderDB = new OrderRespository(connectionString);
    }

    public async Task<Order> CreateOrder(Order order, IEnumerable<Orderline> orderlines)
    {
        using IDbConnection dbConnection = new SqlConnection(connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            order = await _orderDB.Create(order, transaction);

            foreach (var orderline in orderlines)
            {
                orderline.OrderID = order.ID;
                await _orderlineService.CreateOrderline(orderline, transaction);

                bool updateSuccessful = false;
                int retryCount = 0;
                const int MaxRetries = 3;
                while (!updateSuccessful && retryCount < MaxRetries)
                {
                    var product = await _productService.GetProductByID(orderline.ProductID);
                    if (product.Stock < orderline.Quantity)
                    {
                        throw new Exception("Not enough stock");
                    }

                    DateTime originalVersion = product.Version;
                    product.Stock -= orderline.Quantity;
                    product.Version = DateTime.UtcNow;

                    updateSuccessful = await _productService.TryUpdateProduct(product, originalVersion);
                    retryCount++;
                }

                if (!updateSuccessful)
                {
                    throw new Exception("Concurrency conflict");
                }
            }
            transaction.Commit();
            return order;
        }
        catch (Exception e)
        {
            transaction.Rollback();
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
}