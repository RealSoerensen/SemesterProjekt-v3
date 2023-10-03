using API.Models;
using System.Data;
using Dapper;
using RESTful_API.DAL;

namespace API.DAL.CustomerDA;

public class CustomerDB : ICustomer
{
    private readonly IDbConnection _connection;

    public CustomerDB()
    {
        _connection = DBConnection.Instance().GetConnection();
    }

    public Customer Create(Customer obj)
    {
        string insertQuery = @"
                        INSERT INTO Customer (FirstName, LastName, AddressId, Email, Phone)
                        VALUES (@FirstName, @LastName, @Address.Id, @Email, @Phone);
                        SELECT CAST(SCOPE_IDENTITY() as bigint);";

        try
        {
            long generatedId = _connection.QuerySingle<long>(insertQuery, obj);
            obj.Id = generatedId;
        } 
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return obj;
    }

    public bool Delete(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(Customer obj)
    {
        throw new NotImplementedException();
    }
}