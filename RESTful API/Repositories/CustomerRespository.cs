using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories;

public class CustomerRespository
{
    private readonly string _connectionString;

    public CustomerRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Customer> Create(Customer obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            // Updated SQL insert statement to include OUTPUT INSERTED.ID
            const string insertCustomerQuery = @"
            INSERT INTO Customer (FirstName, LastName, AddressId, Email, PhoneNo, Password, RegisterDate)
            OUTPUT INSERTED.ID
            VALUES (@FirstName, @LastName, @AddressId, @Email, @PhoneNo, @Password, @RegisterDate)";

            // Execute the query and store the returned ID in a variable
            var customerId = await dbConnection.ExecuteScalarAsync<long>(insertCustomerQuery, obj, transaction);

            // Commit the transaction as the insert was successful
            transaction.Commit();

            // Update the Customer object with the new ID
            obj.ID = customerId;

            // Return the updated Customer object
            return obj;
        }
        catch (Exception)
        {
            // Rollback the transaction in case of an error
            transaction.Rollback();
            throw;
        }
    }

    public async Task<List<Customer>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Customer WHERE FirstName <> @DeletedCustomer";
        var customerList = await dbConnection.QueryAsync<Customer>(sql, new { DeletedCustomer = "" });
        return customerList.ToList();
    }

    public async Task<bool> Update(Customer obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, AddressId = @AddressId, Email = @Email, PhoneNo = @PhoneNo, Password = @Password WHERE Id = @Id";
            await dbConnection.ExecuteAsync(sql, obj, transaction);
            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<bool> CheckEmailExists(string email)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();

        const string sql = "SELECT TOP 1 Email FROM Customer WHERE Email = @Email";

        var result = await dbConnection.QueryAsync<string>(sql, new { Email = email });

        return result.FirstOrDefault() != null;
    }

    public async Task<Customer> Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "SELECT * FROM Customer WHERE ID = @ID";
            var customer = await dbConnection.QuerySingleAsync<Customer>(sql, new { ID = id }, transaction);
            transaction.Commit();
            return customer;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}