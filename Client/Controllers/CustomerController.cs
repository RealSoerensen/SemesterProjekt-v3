using Client.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Client.Controllers;

internal class CustomerController
{
    private readonly CustomerDA _customerDA;

    public CustomerController()
    {
        _customerDA = new CustomerDA();
    }

    public Customer? Create(Customer customer)
    {
        return _customerDA.Create(customer);
    }

    public Customer? Get(int id)
    {
        return _customerDA.Get(id);
    }

    public List<Customer>? GetAll()
    {
        return _customerDA.GetAll();
    }

    public bool Update(Customer customer)
    {
        return _customerDA.Update(customer);
    }

    public bool Delete(long id)
    {
        return _customerDA.Delete(id);
    }
}