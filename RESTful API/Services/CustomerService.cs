using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.CustomerDA;

namespace RESTful_API.Services;

public class CustomerService
{
    private readonly ICustomerDA _customerDB;
    private readonly OrderService _orderService;

    public CustomerService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _customerDB = new CustomerRespository(connectionString);
        _orderService = new OrderService();
    }

    public Customer CreateCustomer(Customer customer)
    {
        try
        {
            return _customerDB.Create(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public Customer? GetCustomerByEmail(string email)
    {
        try
        {
            return _customerDB.GetByEmail(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public List<Customer> GetAllCustomers()
    {
        try
        {
            return _customerDB.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            string email = customer.Email;
            List<Order> orders = _orderService.GetOrdersByCustomerEmail(email);
            foreach (var order in orders)
            {
                order.CustomerEmail = email;
                _orderService.UpdateOrder(order);
            }
            return _customerDB.Update(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool DeleteCustomer(string email)
    {
        try
        {
            return _customerDB.DeleteByEmail(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}