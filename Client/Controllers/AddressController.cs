using Client.DAL;
using Models;

namespace Client.Controllers;

internal class AddressController
{
    private readonly AddressDA _addressDA = new();

    public Task<Address?> Create(Address address)
    {
        return _addressDA.Create(address);
    }

    public Task<Address?> Get(long Id)
    {
        return _addressDA.Get(Id);
    }

    public Task<bool> Update(Address address)
    {
        return _addressDA.Update(address);
    }
}