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
        const string insertQuery = @"
                        INSERT INTO Customers (FirstName, LastName, AddressId, Email, PhoneNo)
                        VALUES (@FirstName, @LastName, @AddressId, @Email, @PhoneNo);";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        connection.Execute(insertQuery, obj);

        return obj;
    }

    public bool Delete(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer? Get(long id)
    {
        throw new NotSupportedException();
    }

    public List<Customer> GetAll()
    {
        const string selectQuery = "SELECT * FROM Customers;";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.Query<Customer>(selectQuery).ToList();
    }

    public Customer? GetByEmail(string email)
    {
        const string selectQuery = @"
                        SELECT * FROM Customers
                        WHERE Email = @Email;";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.QueryFirstOrDefault<Customer>(selectQuery, new { Email = email });
    }

    public bool Update(Customer obj)
    {
        throw new NotImplementedException();
    }
}