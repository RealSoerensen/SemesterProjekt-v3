using Client.DAL;
using Models;

namespace Client.Controllers;

internal class AddressController
{
    private readonly AddressDA _addressDA = new();

    public Address? Create(Address address)
    {
        return _addressDA.Create(address);
    }

    public Address? Get(long Id)
    {
        return _addressDA.Get(Id);
    }

    public List<Address> GetAll()
    {
        return _addressDA.GetAll();
    }

    public bool Update(Address address)
    {
        return _addressDA.Update(address);
    }

    public bool Delete(Address adress)
    {
        return _addressDA.Update(adress);
    }
}