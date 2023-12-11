using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories;

public class OrderlineRepository
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

    public async Task<List<Orderline>> GetAllOrderlines()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Orderline";
        var orderlineList = await dbConnection.QueryAsync<Orderline>(sql);
        return orderlineList.ToList();
    }
}