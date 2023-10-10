using Models;
using RESTful_API.Repositories.AddressDA;

namespace RESTful_API.Services;

public class AddressService
{
    private readonly IAddressDA _addressDB;

    public AddressService(IAddressDA addressDB)
    {
        _addressDB = addressDB;
    }

    public Address? Create(Address address)
    {
        return _addressDB.Create(address);
    }

    public Address? Get(long id)
    {
        return _addressDB.Get(id);
    }

    public List<Address> GetAll()
    {
        return _addressDB.GetAll();
    }

    public bool Update(Address address)
    {
        return _addressDB.Update(address);
    }

    public bool Delete(Address address)
    {
        return _addressDB.Delete(address);
    }
}
