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

    public async Task<Orderline> Create(Orderline obj, IDbTransaction? transaction = null)
    {
        const string sql = "INSERT INTO Orderline (OrderId, ProductId, Quantity, PriceAtTimeOfOrder) VALUES (@OrderId, @ProductId, @Quantity, @PriceAtTimeOfOrder);";

        // Use the connection associated with the transaction if it's provided
        if (transaction == null)
        {
            // Create a new connection and manage the transaction internally if none is provided
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            using var newTransaction = dbConnection.BeginTransaction();
            try
            {
                await dbConnection.ExecuteAsync(sql, obj, newTransaction);
                newTransaction.Commit();
            }
            catch
            {
                newTransaction.Rollback();
                throw;
            }
        }
        else
        {
            try
            {
                if (transaction.Connection != null) await transaction.Connection.ExecuteAsync(sql, obj, transaction);
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
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

    public async Task<List<Orderline>> GetOrderlinesByOrderID(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Orderline WHERE OrderId = @Id";
        var orderlineList = await dbConnection.QueryAsync<Orderline>(sql, new { Id = id });
        return orderlineList.ToList();
    }
}