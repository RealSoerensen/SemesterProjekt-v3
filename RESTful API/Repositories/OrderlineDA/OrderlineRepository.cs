using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories.OrderlineDA;

public class OrderlineRepository : IOrderlineDA
{
    private readonly string _connectionString;

    public OrderlineRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Orderline> Create(Orderline obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "INSERT INTO Orderline (OrderId, ProductId, Quantity, PriceAtTimeOfOrder) VALUES (@OrderId, @ProductId, @Quantity, @PriceAtTimeOfOrder);";
            await dbConnection.ExecuteAsync(sql, obj, transaction);
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
            const string sql = "DELETE FROM Orderline WHERE Id = @Id";
            await dbConnection.ExecuteAsync(sql, id, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return true;
    }

    public Task<Orderline> Get(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Orderline>> GetOrderlines(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "SELECT * FROM Orderline WHERE OrderID = @Id";
            var orderline = await dbConnection.QueryAsync<Orderline>(sql, new { Id = id }, transaction);
            transaction.Commit();
            return orderline.ToList(); ;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<List<Orderline>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Orderline";
        var orderLineList = await dbConnection.QueryAsync<Orderline>(sql);
        return orderLineList.ToList();
    }

    public async Task<bool> Update(Orderline obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "UPDATE Orderline SET OrderId = @OrderId, ProductId = @ProductId, Quantity = @Quantity WHERE Id = @Id";
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
}