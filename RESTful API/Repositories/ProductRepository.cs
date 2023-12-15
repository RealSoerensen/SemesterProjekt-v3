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
            // Define the SQL query for inserting a product and returning the new ID
            const string insertQuery = @"
            INSERT INTO [Product] (Description, Image, SalePrice, PurchasePrice, NormalPrice, Name, Stock, Brand, Category, Inactive, Version)
            VALUES (@Description, @Image, @SalePrice, @PurchasePrice, @NormalPrice, @Name, @Stock, @Brand, @Category, @Inactive, @Version);
            SELECT CAST(SCOPE_IDENTITY() as bigint);"; // Use SCOPE_IDENTITY() to return the ID

            // Execute the query and get the ID of the inserted product
            var id = await dbConnection.QuerySingleAsync<long>(insertQuery, product, transaction);

            // Set the ID of the product to the ID returned from the query
            product.ID = id;

            // Commit the transaction
            transaction.Commit();
            return product;
        }
        catch (Exception)
        {
            transaction.Rollback(); // Rollback the transaction if there's an error
            throw;
        }
    }



    public async Task<List<Product>> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        const string sql = "SELECT * FROM Product WHERE Description <> @TestDescription";
        var productList = await dbConnection.QueryAsync<Product>(sql, new { TestDescription = "TestDesc" });
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

    public async Task<int> UpdateProductIfVersionMatches(Product product, DateTime originalVersion)
    {
        await using var dbConnection = new SqlConnection(_connectionString);
        await dbConnection.OpenAsync();

        const string sql = @"
        UPDATE Product 
        SET Stock = @Stock, Version = @NewVersion 
        WHERE ID = @ID AND Version = @OriginalVersion";

        var parameters = new DynamicParameters();
        parameters.Add("Stock", product.Stock);
        parameters.Add("NewVersion", product.Version, DbType.DateTime2);
        parameters.Add("ID", product.ID);
        parameters.Add("OriginalVersion", originalVersion, DbType.DateTime2);

        return await dbConnection.ExecuteAsync(sql, parameters);
    }
}