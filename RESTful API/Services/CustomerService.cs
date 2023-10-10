using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.CustomerDA;
using System;

namespace RESTful_API.Services;

public class CustomerService
{
    private readonly ICustomerDA _customerDB;

    public CustomerService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _customerDB = new CustomerRespository(connectionString);
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
            return _customerDB.Update(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }

    public bool DeleteCustomer(Customer customer)
    {
        try
        {
            return _customerDB.Delete(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; // Rethrow the exception for higher-level error handling
        }
    }
}

