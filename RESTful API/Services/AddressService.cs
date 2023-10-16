using Models;
using RESTful_API.Repositories;
using RESTful_API.Repositories.AddressDA;

namespace RESTful_API.Services;

public class AddressService
{
    private readonly IAddressDA _addressDB;

    public AddressService()
    {
        var connectionString = DBConnection.GetConnectionString();
        _addressDB = new AddressRespository(connectionString);
    }

    public Address CreateAddress(Address address)
    {
        try
        {
            return _addressDB.Create(address); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Address GetAddress(long id)
    {
        try
        {
            return _addressDB.Get(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Address> GetAllAddresses()
    {
        try
        {
            return _addressDB.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateAddress(Address address)
    {
        try
        {
            return _addressDB.Update(address);
        }
        catch (Exception e) 
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteAddress(long id)
    {
        try
        {
            return _addressDB.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
