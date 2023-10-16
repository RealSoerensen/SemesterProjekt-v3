using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace RESTful_API.Repositories.ProductDescriptionDA;

public class ProductDescriptionRepository : IProductDescriptionDA
{
    private readonly string _connectionString;

    public ProductDescriptionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ProductDescription Create(ProductDescription productDescription)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            string insertProductDescriptionQuery = "INSERT INTO ProductDescription (Description, Image, Price, Name, Stock) " +
                                          "VALUES (@Description, @Image, @Price, @Name, @Stock)";
            dbConnection.Execute(insertProductDescriptionQuery, productDescription, transaction);

            // Commit the transaction as the insert was successful
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return productDescription;
    }

    public bool Delete(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "DELETE FROM ProductDescription WHERE Id = @Id";
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

    public ProductDescription Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();

        using var transaction = dbConnection.BeginTransaction();
        try
        {
            var sql = "SELECT * FROM ProductDescription WHERE Id = @Id";
            var productDescription = dbConnection.QuerySingle<ProductDescription>(sql, new { Id = id }, transaction);
            transaction.Commit();
            return productDescription;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<ProductDescription> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        var sql = "SELECT * FROM ProductDescription";
        return dbConnection.Query<ProductDescription>(sql).ToList();
    }

    public bool Update(ProductDescription productDescription)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "UPDATE ProductDescription SET Description = @Description, Image = @Image, Price = @Price, Name = @Name, Stock = @Stock WHERE Id = @Id";
            dbConnection.Execute(sql, productDescription, transaction);
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