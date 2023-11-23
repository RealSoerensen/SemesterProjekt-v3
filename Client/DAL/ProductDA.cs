using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class ProductDA : ICRUD<Product>
{
    private readonly string URL = Connection.BaseURL() + "api/Product";
    private readonly HttpClient _client = new();

    public async Task<Product?> Create(Product obj)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(URL, httpContent);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Product>(jsonResponse);
    }

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync(URL + "/" + id);
        return response.IsSuccessStatusCode;
    }

    public async Task<Product?> Get(long id)
    {
        var response = await _client.GetAsync(URL + "/" + id);
        if (!response.IsSuccessStatusCode) return null;
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Product>(jsonResponse);
    }

    public async Task<List<Product>> GetAll()
    {
        try
        {
            var response = await _client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
                return list ?? new List<Product>();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return new List<Product>();
    }

    public async Task<bool> Update(Product obj)
    {
        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(URL, httpContent);
        return response.IsSuccessStatusCode;
    }
}