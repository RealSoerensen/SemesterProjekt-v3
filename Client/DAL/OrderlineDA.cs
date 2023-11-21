using Models;
using System.Net.Http.Json;

namespace Client.DAL;

internal class OrderlineDA : ICRUD<Orderline>
{
    private readonly string URL = Connection.BaseURL() + "api/Orderline";
    private readonly HttpClient _client = new();

    public async Task<Orderline?> Create(Orderline obj)
    {
        var response = await _client.PostAsJsonAsync(URL, obj);
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Orderline>() : null;
    }

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync(URL + "/" + id);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Orderline>?> GetOrderlines(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<Orderline>>() : new List<Orderline>();
    }

    public async Task<List<Orderline>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Orderline>();
        var result = await response.Content.ReadFromJsonAsync<List<Orderline>>();
        return result ?? new List<Orderline>();
    }

    public async Task<bool> Update(Orderline obj)
    {
        var response = await _client.PutAsJsonAsync(URL, obj);
        return response.IsSuccessStatusCode;
    }

    public Task<Orderline?> Get(long id)
    {
        throw new NotImplementedException();
    }
}