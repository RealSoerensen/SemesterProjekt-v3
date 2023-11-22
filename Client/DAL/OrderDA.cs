using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class OrderDA : ICRUD<Order>
{
    private readonly string URL = Connection.BaseURL() + "api/Order";
    private readonly HttpClient _client = new();

    public async Task<Order?> Create(Order obj)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(URL, httpContent);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Order>(jsonResponse);
    }

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync(URL + "/" + id);
        return response.IsSuccessStatusCode;
    }

    public async Task<Order?> Get(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Order>(jsonResponse);
    }

    public async Task<List<Order>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Order>();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var list = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
        return list ?? new List<Order>();
    }

    public async Task<bool> Update(Order obj)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(URL, httpContent);
        return response.IsSuccessStatusCode;
    }
}