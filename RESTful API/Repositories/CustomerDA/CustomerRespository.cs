using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using RESTful_API.Services;
using System.Data;

namespace RESTful_API.Repositories.CustomerDA;

public class CustomerRespository : ICustomerDA
{
    private readonly string _connectionString;

    public CustomerRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Customer Create(Customer obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            string insertCustomerQuery = "INSERT INTO Customer (FirstName, LastName, AddressId, Email, PhoneNo, Password, RegisterDate) " +
                                         "VALUES (@FirstName, @LastName, @AddressId, @Email, @PhoneNo, @Password, @RegisterDate)";
            dbConnection.Execute(insertCustomerQuery, obj, transaction); // Use Execute method for insert

            // Commit the transaction as the insert was successful
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return obj;
    }

    public bool Delete(long id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteByEmail(string email)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "DELETE FROM Customer WHERE Email = @Email";
            dbConnection.Execute(sql, email, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
        return true;
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
        return dbConnection.Query<Customer>(sql).ToList();
    }

    public Customer? GetByEmail(string email)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();

        var sql = "SELECT * FROM Customer WHERE Email = @Email";
        return dbConnection.QuerySingleOrDefault<Customer>(sql, new { Email = email });
    }

    public bool Update(Customer obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, AddressId = @AddressId, Email = @Email, PhoneNo = @PhoneNo, Password = @Password WHERE Email = @Email";
            dbConnection.Execute(sql, obj, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return true;
    }
}