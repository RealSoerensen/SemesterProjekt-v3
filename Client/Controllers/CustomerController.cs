using Client.DAL;
using Models;

namespace Client.Controllers;

internal class CustomerController
{
    private readonly CustomerDA _customerDA = new();

    public Task<Customer?> Create(Customer customer, Address address)
    {
        return _customerDA.Create(customer, address);
    }

    public Task<List<Customer>> GetAll()
    {
        return _customerDA.GetAll();
    }

    public Task<bool> Update(Customer customer)
    {
        return _customerDA.Update(customer);
    }
}