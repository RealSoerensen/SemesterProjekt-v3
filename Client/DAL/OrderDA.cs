using Models;
using System.Net.Http.Json;

namespace Client.DAL;

internal class OrderDA : ICRUD<Order>
{
    private readonly string URL = Connection.BaseURL() + "api/Order";
    private readonly HttpClient _client = new();

    public async Task<Order?> Create(Order obj)
    {
        var response = await _client.PostAsJsonAsync(URL, obj);
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Order>() : null;
    }

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync(URL + "/" + id);
        return response.IsSuccessStatusCode;
    }

    public async Task<Order?> Get(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Order>() : null;
    }

    public async Task<List<Order>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Order>();
        var result = await response.Content.ReadFromJsonAsync<List<Order>>();
        return result ?? new List<Order>();
    }

    public async Task<bool> Update(Order obj)
    {
        var response = await _client.PutAsJsonAsync(URL, obj);
        return response.IsSuccessStatusCode;
    }
}