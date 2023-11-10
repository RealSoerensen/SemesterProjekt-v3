using Models;
using System.Net.Http.Json;

namespace Client.DAL;

internal class AddressDA : ICRUD<Address>
{
    private readonly string URL = Connection.BaseURL() + "api/Address";
    private readonly HttpClient _client = new();

    public Address? Create(Address obj)
    {
        var response = _client.PostAsJsonAsync(URL, obj).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Address>().Result;
        }
        return null;
    }

    public bool Delete(long id)
    {
        var response = _client.DeleteAsync(URL + "/" + id).Result;
        return response.IsSuccessStatusCode;
    }

    public Address? Get(long id)
    {
        var response = _client.GetAsync(URL + "/" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Address>().Result;
        }
        return null;
    }

    public List<Address> GetAll()
    {
        var response = _client.GetAsync(URL).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<List<Address>>().Result;
            if (result != null)
                return result;
        }
        return new List<Address>();
    }

    public bool Update(Address obj)
    {
        var response = _client.PutAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode;
    }
}