using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Product> Create(Product product)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            // Define the SQL query for inserting a product
            const string insertQuery = @"INSERT INTO [Product] (Description, Image, SalePrice, PurchasePrice, NormalPrice, Name, Stock, Brand, Category, Inactive)
                                VALUES (@Description, @Image, @SalePrice, @PurchasePrice, @NormalPrice, @Name, @Stock, @Brand, @Category, @Inactive)";

            // Execute the query and pass the product and the transaction as parameters
            await dbConnection.ExecuteAsync(insertQuery, product, transaction: transaction);
            transaction.Commit(); // Commit the transaction after the insert
        }
        catch (Exception)
        {
            transaction.Rollback(); // Rollback the transaction if there's an error
            throw;
        }

        return product;
    }


    public async Task<List<Product>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Product";
        var productList = await dbConnection.QueryAsync<Product>(sql);
        return productList.ToList();
    }

    public async Task<bool> Update(Product product)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "UPDATE Product SET Description = @Description, Image = @Image, SalePrice = @SalePrice, PurchasePrice = @PurchasePrice, NormalPrice = @NormalPrice, Name = @Name, Stock = @Stock, Brand = @Brand, Category = @Category, Inactive = @Inactive WHERE ID = @ID";
            await dbConnection.ExecuteAsync(sql, product, transaction);
            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<Product> Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "SELECT * FROM Product WHERE ID = @ID";
            var product = await dbConnection.QuerySingleAsync<Product>(sql, new { ID = id }, transaction);
            transaction.Commit();
            return product;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<List<Product>> GetProductsByCategory(int category)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Product WHERE Category = @Category";
        var productList = await dbConnection.QueryAsync<Product>(sql, new { Category = category });
        return productList.ToList();
    }

    public async Task<bool> Delete(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "DELETE FROM Product WHERE ID = @ID";
            await dbConnection.ExecuteAsync(sql, new { ID = id }, transaction);
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