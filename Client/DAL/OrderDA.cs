using Models;
using Newtonsoft.Json;

namespace Client.DAL;

internal class OrderDA
{
    private readonly string URL = Connection.BaseURL() + "api/Order";
    private readonly HttpClient _client = new();

    public async Task<List<Order>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Order>();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var list = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
        return list ?? new List<Order>();
    }
}