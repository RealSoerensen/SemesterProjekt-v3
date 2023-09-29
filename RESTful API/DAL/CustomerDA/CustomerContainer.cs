using API.Models;

namespace API.DAL.CustomerDA;

public class CustomerContainer : ICustomer
{
    private readonly List<Customer> _customers;

    // Private constructor to ensure a single instance.
    private CustomerContainer()
    {
        _customers = new List<Customer>();
    }

    public static CustomerContainer Instance { get; } = new CustomerContainer();

    public Customer Create(Customer obj)
    {
        lock (_customers)
        {
            _customers.Add(obj);
        }
        return obj;
    }

    public Customer? Get(int id)
    {
        lock (_customers)
        {
            return _customers.FirstOrDefault(customer => customer.Id == id) ?? null;
        }
    }

    public List<Customer> GetAll()
    {
        lock (_customers)
        {
            return new List<Customer>(_customers); // Return a copy to prevent modification of the internal list.
        }
    }

    public bool Update(Customer obj)
    {
        lock (_customers)
        {
            var existingCustomer = _customers.FirstOrDefault(customer => customer.Id == obj.Id);
            if (existingCustomer == null) return false;
            _customers.Remove(existingCustomer);
            _customers.Add(obj);
            return true;
        }
    }

    public bool Delete(Customer customer)
    {
        lock (_customers)
        {
            foreach (var c in _customers.Where(c => c.Id == customer.Id))
            {
                return _customers.Remove(c);
            }
        }
        return false;
    }
}