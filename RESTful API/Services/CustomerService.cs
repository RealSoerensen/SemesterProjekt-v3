using Models;
using RESTful_API.Repositories.CustomerDA;

namespace RESTful_API.Services;

public class CustomerService
{
    private readonly ICustomerDA _customerDB;

    public CustomerService(ICustomerDA customerDB)
    {
        _customerDB = customerDB;
    }

    public Customer? Create(Customer customer)
    {
        return _customerDB.Create(customer);
    }

    public Customer? Get(string email)
    {
        return _customerDB.GetByEmail(email);
    }

    public List<Customer> GetAll()
    {
        return _customerDB.GetAll();
    }

    public bool Update(Customer customer)
    {
        return _customerDB.Update(customer);
    }

    public bool Delete(Customer customer)
    {
        return _customerDB.Delete(customer);
    }

}
