using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Models;
using RESTful_API.Services;
using System.Collections.Generic;
using System.Data;

namespace RESTful_API.Repositories.CustomerDA;

public class CustomerRespository : ICustomerDA
{
    private readonly string _connectionString;

    public CustomerRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Customer Create(Customer obj) {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try {
            // Updated SQL insert statement to include OUTPUT INSERTED.ID
            string insertCustomerQuery = @"
            INSERT INTO Customer (FirstName, LastName, AddressId, Email, PhoneNo, Password, RegisterDate)
            OUTPUT INSERTED.ID
            VALUES (@FirstName, @LastName, @AddressId, @Email, @PhoneNo, @Password, @RegisterDate)";

            // Execute the query and store the returned ID in a variable
            var customerId = dbConnection.ExecuteScalar<long>(insertCustomerQuery, obj, transaction);

            // Commit the transaction as the insert was successful
            transaction.Commit();

            // Update the Customer object with the new ID
            obj.ID = customerId;

            // Return the updated Customer object
            return obj;
        } catch (Exception) {
            // Rollback the transaction in case of an error
            transaction.Rollback();
            throw;
        }
    }


    public bool Delete(long id) {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try {
            var sql = "DELETE FROM Customer WHERE Id = @Id";
            int rowsAffected = dbConnection.Execute(sql, new { Id = id }, transaction: transaction);
            transaction.Commit();
            return rowsAffected > 0;
        } catch (Exception) {
            transaction.Rollback();
            throw;
        }
    }


    public Customer Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try {
            var sql = "SELECT * FROM [Customer] WHERE ID = @ID";
            var customer = dbConnection.QuerySingle<Customer>(sql, new { ID = id }, transaction);
            transaction.Commit();
            return customer;
        } catch (Exception) {
            transaction.Rollback();
            throw;
        }
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
        return dbConnection.QueryFirstOrDefault<Customer>(sql, new { Email = email });
    }

    public bool Update(Customer obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, AddressId = @AddressId, Email = @Email, PhoneNo = @PhoneNo, Password = @Password WHERE Id = @Id";
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

    public bool CheckEmailExists(string email) {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();

        var sql = "SELECT TOP 1 Email FROM Customer WHERE Email = @Email";

        var result = dbConnection.Query<string>(sql, new { Email = email }).FirstOrDefault();

        return result != null;
    }

}