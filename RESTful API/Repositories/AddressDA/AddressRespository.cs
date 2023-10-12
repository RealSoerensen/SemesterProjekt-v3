using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using RESTful_API.Services;
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
            var sql = "INSERT INTO Address (street, city, zipCode, houseNumber) VALUES (@Street, @City, @Zip, @HouseNumber); SELECT CAST(SCOPE_IDENTITY() as bigint);";
            obj.Id = dbConnection.QuerySingle<int>(sql, obj, transaction);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
        return obj;
    }

    public bool Delete(Address obj)
    {
        throw new NotImplementedException();
    }

    public Address Get(long id)
    {
        throw new NotImplementedException();
    }

    public List<Address> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(Address obj)
    {
        throw new NotImplementedException();
    }
}