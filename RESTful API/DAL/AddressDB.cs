using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace RESTful_API.DAL;

public class AddressDB : ICRUD<Address>
{
    private readonly string _connectionString;

    public AddressDB(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Address Create(Address obj)
    {
        const string insertQuery = @"
                        INSERT INTO Address (Street, City, State, Zip, Country)
                        VALUES (@Street, @City, @State, @Zip, @Country);
                        SELECT CAST(SCOPE_IDENTITY() as bigint);";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var id = connection.ExecuteScalar<long>(insertQuery, obj);
        obj.Id = id;
        connection.Close();
        return obj;
    }

    public bool Delete(Address obj)
    {
        throw new NotImplementedException();
    }

    public Address? Get(long id)
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