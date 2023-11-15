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

    public Orderline Create(Orderline obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "INSERT INTO Orderline (OrderId, ProductId, Quantity, PriceAtTimeOfOrder) VALUES (@OrderId, @ProductId, @Quantity, @PriceAtTimeOfOrder);";
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
            const string sql = "DELETE FROM Orderline WHERE Id = @Id";
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

    public Orderline Get(long id)
    {
        throw new NotImplementedException();
    }

    public List<Orderline> GetOrderlines(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "SELECT * FROM Orderline WHERE OrderID = @Id";
            var orderline = dbConnection.Query<Orderline>(sql, new { Id = id }, transaction).ToList();
            transaction.Commit();
            return orderline;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<Orderline> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Orderline";
        return dbConnection.Query<Orderline>(sql).ToList();
    }

    public bool Update(Orderline obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "UPDATE Orderline SET OrderId = @OrderId, ProductId = @ProductId, Quantity = @Quantity WHERE Id = @Id";
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