using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories;

public class OrderRespository
{
    private readonly string _connectionString;

    public OrderRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Order> Create(Order obj, IDbTransaction? transaction = null)
    {
        // Only create a new connection if no transaction is provided
        if (transaction == null)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            return await CreateOrderInternal(dbConnection, obj, null);
        }

        // Use the connection from the transaction
        return await CreateOrderInternal(transaction.Connection, obj, transaction);
    }

    private async Task<Order> CreateOrderInternal(IDbConnection dbConnection, Order obj, IDbTransaction? transaction)
    {
        const string sql = "INSERT INTO [Order] (CustomerId, Date) VALUES (@CustomerId, @Date); SELECT CAST(SCOPE_IDENTITY() as int)";
        obj.ID = await dbConnection.QuerySingleAsync<int>(sql, obj, transaction);
        return obj;
    }

    public async Task<List<Order>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM [Order]";
        var orderList = await dbConnection.QueryAsync<Order>(sql);
        return orderList.ToList();
    }
}