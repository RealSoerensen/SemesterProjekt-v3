using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace RESTful_API.Repositories;

public class AddressRespository
{
    private readonly string _connectionString;

    public AddressRespository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Address> Create(Address obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "INSERT INTO Address (street, city, zip, houseNumber) VALUES (@Street, @City, @Zip, @HouseNumber); SELECT CAST(SCOPE_IDENTITY() as bigint);";
            obj.ID = await dbConnection.ExecuteScalarAsync<long>(sql, obj, transaction);
            transaction.Commit();
            return obj;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<Address> Get(long id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();
        try
        {
            const string sql = "SELECT * FROM Address WHERE Id = @Id";
            var address = await dbConnection.QuerySingleAsync<Address>(sql, new { Id = id }, transaction);
            transaction.Commit();
            return address;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<bool> Update(Address obj)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        using var transaction = dbConnection.BeginTransaction();

        try
        {
            const string sql = "UPDATE Address SET street = @Street, city = @City, zip = @Zip, houseNumber = @HouseNumber WHERE Id = @Id";
            await dbConnection.ExecuteAsync(sql, obj, transaction);
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