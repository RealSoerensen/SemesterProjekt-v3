using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace RESTful_API.Repositories.ProductDA;

public class ProductRepository : IProductDA
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Product Create(Product product)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            string insertProductQuery = "INSERT INTO Product (ProductDescriptionID) " +
                                         "VALUES (@ProductDescriptionID)";
            dbConnection.Execute(insertProductQuery, product, transaction);

            // Commit the transaction as the insert was successful
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return product;
    }

    public bool Delete(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "DELETE FROM Product WHERE ProductSN = @ProductSN";
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

    public List<Product> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        var sql = "SELECT * FROM Product";
        return dbConnection.Query<Product>(sql).ToList();
    }

    public bool Update(Product product)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "UPDATE Product SET ProductDescriptionID = @ProductDescriptionID WHERE ProductSN = @ProductSN";
            dbConnection.Execute(sql, product, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return true;
    }

    public Product Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            var sql = "SELECT * FROM Product WHERE ProductSN = @ProductSN";
            var product = dbConnection.QuerySingle<Product>(sql, new { ProductSN = id }, transaction);
            transaction.Commit();
            return product;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}