using System.Net.Http.Json;
using Models;

namespace Client.DAL;

internal class CustomerDA
{
    private readonly string URL = Connection.BaseURL() + "api/Customer";
    private readonly HttpClient _client;

    public Customer? Create(Customer obj)
    {
        throw new NotImplementedException();
    }

    public Customer? GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Customer>? GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public bool Update(Customer obj)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Customer obj)
    {
        throw new NotImplementedException();
    }
}