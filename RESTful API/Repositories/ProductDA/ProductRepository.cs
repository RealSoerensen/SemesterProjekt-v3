using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

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
            const string insertQuery = @"INSERT INTO [Product] (Description, Image, SalePrice, PurchasePrice, NormalPrice, Name, Stock, Brand, Category, Inactive)
                                VALUES (@Description, @Image, @SalePrice, @PurchasePrice, @NormalPrice, @Name, @Stock, @Brand, @Category, @Inactive)";

            // Execute the query and pass the product and the transaction as parameters
            dbConnection.Execute(insertQuery, product, transaction: transaction);
            transaction.Commit(); // Commit the transaction after the insert
        }
        catch (Exception)
        {
            transaction.Rollback(); // Rollback the transaction if there's an error
            throw;
        }

        return product;
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

    bool ICRUD<Product>.Delete(long id) {
        throw new NotImplementedException();
    }
}