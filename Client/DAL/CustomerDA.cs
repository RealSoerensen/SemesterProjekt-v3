using System.Net.Http.Json;
using Models;

namespace Client.DAL;

internal class CustomerDA
{
    private readonly string URL = Connection.BaseURL() + "api/Customer";

    public Customer? Create(Customer obj)
    {
        using var client = new HttpClient();
        var response = client.PostAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode ? response.Content.ReadFromJsonAsync<Customer>().Result : null;
    }

    public Customer? GetCustomerById(int id)
    {
        using var client = new HttpClient();
        var response = client.GetAsync(URL + "?id=" + id).Result;
        return response.IsSuccessStatusCode ? response.Content.ReadFromJsonAsync<Customer>().Result : null;
    }

    public List<Customer>? GetAllCustomers()
    {
        using var client = new HttpClient();
        var response = client.GetAsync(URL).Result;
        return response.IsSuccessStatusCode ? response.Content.ReadFromJsonAsync<List<Customer>>().Result : new List<Customer>();
    }

    public bool Update(Customer obj)
    {
        using var client = new HttpClient();
        var response = client.PutAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode;
    }

    public bool Delete(Customer obj)
    {
        using var client = new HttpClient();
        var response = client.DeleteAsync(URL + "/" + obj.Id).Result;
        return response.IsSuccessStatusCode;
    }
}