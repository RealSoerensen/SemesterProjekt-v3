using Client.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Client.Controllers;

internal class AddressController
{
    private readonly AddressDA _addressDA;
    
    public AddressController()
    {
        _addressDA = new AddressDA();
    } 
    public Address? Create(Address address)
    {
        return _addressDA.Create(address);
    }
    public Address? Get(int Id)
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