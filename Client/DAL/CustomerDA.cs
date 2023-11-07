using System.Net.Http.Json;
using Models;

namespace Client.DAL;

internal class CustomerDA : ICRUD<Customer>
{
    private readonly string URL = Connection.BaseURL() + "api/Customer";
    private readonly HttpClient _client = new();

    public Customer? Create(Customer obj)
    {
        var response = _client.PostAsJsonAsync(URL, obj).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Customer>().Result;
        }
        return null;
    }

    public bool Update(Customer obj)
    {
        var response = _client.PutAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode;
    }

    public Customer? Get(long id)
    {
        var response = _client.GetAsync(URL + "/" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Customer>().Result;
        }
        return null;
    }

    public List<Customer> GetAll()
    {
        var response = _client.GetAsync(URL).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<List<Customer>>().Result;
            if (result != null)
                return result;
        }
        return new List<Customer>();
    }

    public bool Delete(long id)
    {
        var response = _client.DeleteAsync(URL + "/" + id).Result;
        return response.IsSuccessStatusCode;
    }
}