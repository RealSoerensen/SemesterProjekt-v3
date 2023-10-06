using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace RESTful_API.DAL;

public class CustomerDB : ICRUD<Customer>
{
    private readonly string _connectionString;

    public CustomerDB(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Customer Create(Customer obj)
    {
        const string insertQuery = @"
                        INSERT INTO Customer (FirstName, LastName, AddressId, Email, PhoneNo)
                        VALUES (@FirstName, @LastName, @AddressId, @Email, @PhoneNo);
                        SELECT CAST(SCOPE_IDENTITY() as bigint);";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var id = connection.ExecuteScalar<long>(insertQuery, obj);
        obj.Id = id;
        connection.Close();
        return obj;
    }

    public bool Delete(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer? Get(long id)
    {
        const string selectQuery = @"
                        SELECT * FROM Customer
                        WHERE Id = @Id;";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var customer = connection.QueryFirstOrDefault<Customer>(selectQuery, new { Id = id });
        connection.Close();
        return customer;
    }

    public List<Customer> GetAll()
    {
        const string selectQuery = "SELECT * FROM Customer;";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var customers = connection.Query<Customer>(selectQuery).ToList();
        connection.Close();
        return customers;
    }

    public bool Update(Customer obj)
    {
        throw new NotImplementedException();
    }
}