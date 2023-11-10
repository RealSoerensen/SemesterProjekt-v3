using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class AddressDA : ICRUD<Address>
{
    private readonly string URL = Connection.BaseURL() + "api/Address";
    private readonly HttpClient _client = new();

    public Address? Create(Address obj)
    {
        var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = _client.PostAsync(URL, content).Result;
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<Address>(jsonResponse);
    }

    public bool Delete(long id)
    {
        var response = _client.DeleteAsync(URL + "/" + id).Result;
        return response.IsSuccessStatusCode;
    }

    public Address? Get(long id)
    {
        var response = _client.GetAsync(URL + "/" + id).Result;
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<Address>(jsonResponse);
    }

    public List<Address> GetAll()
    {
        var response = _client.GetAsync(URL).Result;
        if (!response.IsSuccessStatusCode) return new List<Address>();
        var jsonResponse = response.Content.ReadAsStringAsync().Result;
        var addressList = JsonConvert.DeserializeObject<List<Address>>(jsonResponse);
        return addressList ?? new List<Address>();
    }

    public bool Update(Address obj)
    {
        var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = _client.PutAsync(URL, content).Result;
        return response.IsSuccessStatusCode;
    }
}