using Models;
using System.Net.Http.Json;

namespace Client.DAL;

internal class OrderDA : ICRUD<Order>
{
    private readonly string URL = Connection.BaseURL() + "api/Order";
    private readonly HttpClient _client = new();

    public Order? Create(Order obj)
    {
        var response = _client.PostAsJsonAsync(URL, obj).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Order>().Result;
        }
        return null;
    }

    public bool Delete(long id)
    {
        var response = _client.DeleteAsync(URL + "/" + id).Result;
        return response.IsSuccessStatusCode;
    }

    public Order? Get(long id)
    {
        var response = _client.GetAsync(URL + "/" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Order>().Result;
        }
        return null;
    }

    public List<Order> GetAll()
    {
        var response = _client.GetAsync(URL).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<List<Order>>().Result;
            if (result != null)
                return result;
        }
        return new List<Order>();
    }

    public bool Update(Order obj)
    {
        var response = _client.PutAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode;
    }
}