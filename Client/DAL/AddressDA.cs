using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class AddressDA : ICRUD<Address>
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

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync(URL + "/" + id);
        return response.IsSuccessStatusCode;
    }

    public async Task<Address?> Get(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Address>(jsonResponse);
    }

    public async Task<List<Address>> GetAll()
    {
        var response = await _client.GetAsync(URL);
        if (!response.IsSuccessStatusCode) return new List<Address>();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var addressList = JsonConvert.DeserializeObject<List<Address>>(jsonResponse);
        return addressList ?? new List<Address>();
    }

    public async Task<bool> Update(Address obj)
    {
        var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(URL, content);
        return response.IsSuccessStatusCode;
    }
}