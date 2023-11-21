using Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Client.DAL;

internal class ProductDA : ICRUD<Product>
{
    private readonly string URL = Connection.BaseURL() + "api/Product";
    private readonly HttpClient _client = new();

    public async Task<Product?> Create(Product obj)
    {
        var response = await _client.PostAsJsonAsync(URL, obj);
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
                var productList = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
                if (productList != null) return productList;
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
        var response = await _client.PutAsJsonAsync(URL, obj);
        return response.IsSuccessStatusCode;
    }
}