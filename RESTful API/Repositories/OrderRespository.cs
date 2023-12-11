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
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
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