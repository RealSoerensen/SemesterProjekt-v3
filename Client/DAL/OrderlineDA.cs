using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class OrderlineDA : ICRUD<Orderline>
{
    private readonly string URL = Connection.BaseURL() + "api/Orderline";
    private readonly HttpClient _client = new();

    public async Task<Orderline?> Create(Orderline obj)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(URL, httpContent);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Orderline>(jsonResponse);
    }

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync(URL + "/" + id);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Orderline>?> GetOrderlines(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Orderline>>(jsonResponse);
    }

    public async Task<List<Orderline>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Orderline>();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var list = JsonConvert.DeserializeObject<List<Orderline>>(jsonResponse);
        return list ?? new List<Orderline>();
    }

    public async Task<bool> Update(Orderline obj)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(URL, httpContent);
        return response.IsSuccessStatusCode;
    }

    public Task<Orderline?> Get(long id)
    {
        throw new NotImplementedException();
    }
}