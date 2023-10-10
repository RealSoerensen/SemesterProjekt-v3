using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using RESTful_API.Services;

namespace RESTful_API.Repositories.CustomerDA;

public class CustomerRespository : ICustomerDA
{
    private readonly string _connectionString;
    private readonly AddressService AddressService;

    public CustomerRespository(string connectionString)
    {
        _connectionString = connectionString;
        AddressService = new AddressService();
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