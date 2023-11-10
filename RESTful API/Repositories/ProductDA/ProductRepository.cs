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
            // Define the SQL query for inserting a product
            const string insertQuery = @"INSERT INTO [Product] (Description, Image, SalePrice, PurchasePrice, NormalPrice, Name, Stock, Brand, Category)
                                    VALUES (@Description, @Image, @SalePrice, @PurchasePrice, @NormalPrice, @Name, @Stock, @Brand, @Category)";

            // Execute the query and pass the product as a parameter
            dbConnection.Execute(insertQuery, product);
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
            const string sql = "DELETE FROM Product WHERE ID = @ID";
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
        const string sql = "SELECT * FROM Product";
        return dbConnection.Query<Product>(sql).ToList();
    }

    public bool Update(Product product)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = @"UPDATE Product SET Description = @Description, Image = @Image, SalePrice = @SalePrice, PurchasePrice = @PurchasePrice, NormalPrice = @NormalPrice, Name = @Name, Stock = @Stock, Brand = @Brand, Category = @Category WHERE ID = @ID";
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
            const string sql = "SELECT * FROM Product WHERE ID = @ID";
            var product = dbConnection.QuerySingle<Product>(sql, new { ID = id }, transaction);
            transaction.Commit();
            return product;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<Product> GetProductsByCategory(int category)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Product WHERE Category = @Category";
        return dbConnection.Query<Product>(sql, new { Category = category }).ToList();
    }
}