using Client.DAL;
using Models;

namespace Client.Controllers;

internal class CustomerController
{
    private readonly CustomerDA _customerDA = new();

    public Task<bool> Create(Customer customer, Address address, UserAccount account)
    {
        return _customerDA.Create(customer, address, account);
    }

    public Task<List<Customer>> GetAll()
    {
        var customers = _customerDA.GetAll();

        return _customerDA.GetAll();
    }

    public Task<bool> Update(Customer customer)
    {
        return _customerDA.Update(customer);
    }
}