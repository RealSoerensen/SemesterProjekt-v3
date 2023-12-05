using Models;
using Newtonsoft.Json;

namespace Client.DAL;

internal class OrderlineDA
{
    private readonly string URL = Connection.BaseURL() + "api/Orderline";
    private readonly HttpClient _client = new();

    public async Task<List<Orderline>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Orderline>();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var list = JsonConvert.DeserializeObject<List<Orderline>>(jsonResponse);
        return list ?? new List<Orderline>();
    }
}