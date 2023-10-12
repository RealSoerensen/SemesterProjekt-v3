using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using RESTful_API.Services;
using System.Data;

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
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            string insertCustomerQuery = "INSERT INTO Customers (FirstName, LastName, AddressId, Email, PhoneNo, Password, RegisterDate) " +
                                         "VALUES (@FirstName, @LastName, @AddressId, @Email, @PhoneNo, @Password, @RegisterDate)";
            dbConnection.QuerySingle<int>(insertCustomerQuery, obj, transaction);
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return obj;
    }

    public bool Delete(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer Get(long id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        var sql = "SELECT * FROM Customer";
        var result = dbConnection.Query<Customer>(sql).ToList();

        return result;
    }

    public Customer? GetByEmail(string email)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();

        var sql = "SELECT * FROM Customer WHERE Email = @Email";
        var result = dbConnection.QuerySingleOrDefault<Customer>(sql, new { Email = email });
        return result;
    }

    public bool Update(Customer obj)
    {
        throw new NotImplementedException();
    }
}