﻿using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services;

public class CustomerService
{
    private readonly CustomerRespository _customerDB;

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

    public async Task<Customer> GetCustomerByID(long id)
    {
        try
        {
            return await _customerDB.Get(id);
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
}