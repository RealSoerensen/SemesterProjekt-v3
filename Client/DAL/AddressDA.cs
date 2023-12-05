using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class AddressDA
{
    private readonly string URL = Connection.BaseURL() + "api/Address";
    private readonly HttpClient _client = new();

    public async Task<Address?> Create(Address obj)
    {
        var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(URL, content);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Address>(jsonResponse);
    }

    public async Task<Address?> Get(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Address>(jsonResponse);
    }

    public async Task<bool> Update(Address obj)
    {
        var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(URL, content);
        return response.IsSuccessStatusCode;
    }
}