using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace RESTful_API.Repositories.CustomerDA;

public class CustomerDB : ICustomerDA
{
    private readonly string _connectionString;

    public CustomerDB(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Customer Create(Customer obj)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer Get(long id)
    {
        throw new NotSupportedException();
    }

    public List<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Customer? GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public bool Update(Customer obj)
    {
        throw new NotImplementedException();
    }
}