using Client.DAL;
using Models;

namespace Client.Controllers;

internal class CustomerController
{
    private readonly CustomerDA _customerDA = new();

    public Task<Customer?> Create(Customer customer)
    {
        return _customerDA.Create(customer);
    }

    public Task<Customer?> Get(long id)
    {
        return _customerDA.Get(id);
    }

    public Task<List<Customer>> GetAll()
    {
        return _customerDA.GetAll();
    }

    public Task<bool> Update(Customer customer)
    {
        return _customerDA.Update(customer);
    }

    public Task<bool> Delete(long id)
    {
        return _customerDA.Delete(id);
    }
}