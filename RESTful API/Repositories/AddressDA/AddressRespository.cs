using Dapper;
using Microsoft.Data.SqlClient;
using Models;

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
        throw new NotImplementedException();
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