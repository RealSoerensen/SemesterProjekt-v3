using Models;
using System.Net.Http.Json;

namespace Client.DAL;

internal class OrderlineDA : ICRUD<Orderline>
{
    private readonly string URL = Connection.BaseURL() + "api/Orderline";
    private readonly HttpClient _client = new();

    public Orderline? Create(Orderline obj)
    {
        var response = _client.PostAsJsonAsync(URL, obj).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<Orderline>().Result;
        }
        return null;
    }

    public bool Delete(long id)
    {
        var response = _client.DeleteAsync(URL + "/" + id).Result;
        return response.IsSuccessStatusCode;
    }

    public List<Orderline> Get(long id)
    {
        var response = _client.GetAsync(URL + "/" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<List<Orderline>>().Result;
        }
        return null;
    }

    public List<Orderline> GetAll()
    {
        var response = _client.GetAsync(URL).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<List<Orderline>>().Result;
            if (result != null)
                return result;
        }
        return new List<Orderline>();
    }

    public bool Update(Orderline obj)
    {
        var response = _client.PutAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode;
    }

    Orderline? ICRUD<Orderline>.Get(long id) {
        throw new NotImplementedException();
    }
}