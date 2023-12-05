using Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services;

public class AddressService
{
    private readonly AddressRespository _addressDB;

    public AddressService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _addressDB = new AddressRespository(connectionString);
    }

    public async Task<Address> CreateAddress(Address address)
    {
        try
        {
            return await _addressDB.Create(address);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Address> GetAddress(long id)
    {
        try
        {
            return await _addressDB.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateAddress(Address address)
    {
        try
        {
            return await _addressDB.Update(address);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}