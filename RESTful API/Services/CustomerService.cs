using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.CustomerDA;

namespace RESTful_API.Services;

public class CustomerService
{
    private readonly ICustomerDA _customerDB;

    public CustomerService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _customerDB = new CustomerRespository(connectionString);
    }

    public async Task<Customer> CreateCustomer(Customer customer)
    {
        try
        {
            return await _customerDB.Create(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        try
        {
            return await _customerDB.GetByEmail(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<Customer?> GetCustomer(long id)
    {
        try
        {
            return await _customerDB.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> CheckEmailExists(string email)
    {
        try
        {
            return await _customerDB.CheckEmailExists(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        try
        {
            return await _customerDB.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> UpdateCustomer(Customer customer)
    {
        try
        {
            return await _customerDB.Update(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public async Task<bool> DeleteCustomer(long id)
    {
        try
        {
            return await _customerDB.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}