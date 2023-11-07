using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace RESTful_API.Repositories.AddressDA;

public class AddressRespository : IAddressDA
{
    private readonly string _connectionString;

    public AddressRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Address Create(Address obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            var sql = "INSERT INTO Address (street, city, zip, houseNumber) VALUES (@Street, @City, @Zip, @HouseNumber); SELECT CAST(SCOPE_IDENTITY() as bigint);";
            obj.ID = dbConnection.QuerySingle<int>(sql, obj, transaction);
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
            var sql = "DELETE FROM Address WHERE Id = @Id";
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

    public Address Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            var sql = "SELECT * FROM Address WHERE Id = @Id";
            var address = dbConnection.QuerySingle<Address>(sql, new { Id = id }, transaction);
            transaction.Commit();
            return address;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<Address> GetAll()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        try
        {
            var sql = "SELECT * FROM Address";
            var addresses = dbConnection.Query<Address>(sql).ToList();
            return addresses;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Update(Address obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            var sql = "UPDATE Address SET street = @Street, city = @City, zipCode = @Zip, houseNumber = @HouseNumber WHERE Id = @Id";
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