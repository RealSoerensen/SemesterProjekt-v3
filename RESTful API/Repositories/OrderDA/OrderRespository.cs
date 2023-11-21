using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories.OrderDA;

public class OrderRespository : IOrderDA
{
    private readonly string _connectionString;

    public OrderRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Order> Create(Order obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "INSERT INTO [Order] (CustomerID, Date) VALUES (@CustomerId, @Date); SELECT CAST(SCOPE_IDENTITY() as bigint);";
            obj.ID = await dbConnection.QuerySingleAsync<int>(sql, obj, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
        return obj;
    }

    public async Task<bool> Delete(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "DELETE FROM [Order] WHERE Id = @Id";
            await dbConnection.ExecuteAsync(sql, new { Id = id }, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return true;
    }


    public async Task<Order> Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "SELECT * FROM [Order] WHERE Id = @Id";
            var order = await dbConnection.QuerySingleAsync<Order>(sql, new { Id = id }, transaction);
            transaction.Commit();
            return order;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<List<Order>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM [Order]";
        var orderList = await dbConnection.QueryAsync<Order>(sql);
        return orderList.ToList(); ;
    }

    public async Task<List<Order>> GetOrdersByCustomerID(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM [Order] WHERE CustomerID = @ID";
        var orderList = await dbConnection.QueryAsync<Order>(sql, new { ID = id });
        return orderList.ToList();
    }

    public async Task<bool> Update(Order obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "UPDATE [Order] SET CustomerId = @CustomerId, date = @OrderDate WHERE Id = @Id";

            var parameters = new
            {
                CustomerId = obj.CustomerID,
                OrderDate = obj.Date,
                Id = obj.ID
            };

            await dbConnection.ExecuteAsync(sql, parameters, transaction);
            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}