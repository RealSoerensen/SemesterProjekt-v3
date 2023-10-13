using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace RESTful_API.Repositories.OrderDA;

public class OrderRespository : IOrderDA
{
    private readonly string _connectionString;

    public OrderRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Order Create(Order obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            var sql = "INSERT INTO [Order] (CustomerId, OrderDate, TotalPrice) VALUES (@CustomerId, @OrderDate, @TotalPrice); SELECT CAST(SCOPE_IDENTITY() as bigint);";
            dbConnection.Execute(sql, obj, transaction);
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
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "DELETE FROM [Order] WHERE Id = @Id";
            dbConnection.Execute(sql, id, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return true;
    }

    public Order Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            var sql = "SELECT * FROM [Order] WHERE Id = @Id";
            var order = dbConnection.QuerySingle<Order>(sql, new { Id = id }, transaction);
            transaction.Commit();
            return order;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<Order> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        var sql = "SELECT * FROM [Order]";
        return dbConnection.Query<Order>(sql).ToList();
    }

    public bool Update(Order obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "UPDATE [Order] SET CustomerId = @CustomerId, OrderDate = @OrderDate, TotalPrice = @TotalPrice WHERE Id = @Id";
            dbConnection.Execute(sql, obj, transaction);
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