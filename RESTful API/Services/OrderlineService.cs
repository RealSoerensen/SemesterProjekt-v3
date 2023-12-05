﻿using Models;
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
}