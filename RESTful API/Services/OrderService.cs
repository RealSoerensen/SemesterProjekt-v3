using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services;

public class OrderService
{
    private readonly OrderRespository _orderDB;
    private readonly OrderlineService _orderlineService = new();
    private readonly ProductService _productService = new();

    public OrderService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _orderDB = new OrderRespository(connectionString);
    }

    public async Task<Order> CreateOrder(Order order, IEnumerable<Orderline> orderlines)
    {

        try
        {
            // Create the order
            order = await _orderDB.Create(order);

            foreach (var orderline in orderlines)
            {
                // Set OrderID for each orderline
                orderline.OrderID = order.ID;

                // Create the orderline
                await _orderlineService.CreateOrderline(orderline);

                // Reduce product quantity using update method in ProductService
                var product = await _productService.GetProductByID(orderline.ProductID);
                if (product.Stock < orderline.Quantity)
                {
                    throw new Exception("Not enough stock");
                }
                product.Stock -= orderline.Quantity;
                await _productService.UpdateProduct(product);
            }

            return order;
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