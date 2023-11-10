using Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Client.DAL;

internal class ProductDA : ICRUD<Product>
{
    private readonly string URL = Connection.BaseURL() + "api/Product";
    private readonly HttpClient _client = new();

    public Product? Create(Product obj)
    {
        var response = _client.PostAsJsonAsync(URL, obj).Result;
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Product>(jsonResponse);
        }
        return null;
    }

    public bool Delete(long id)
    {
        var response = _client.DeleteAsync(URL + "/" + id).Result;
        return response.IsSuccessStatusCode;
    }

    public Product? Get(long id)
    {
        var response = _client.GetAsync(URL + "/" + id).Result;
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Product>(jsonResponse);
        }
        return null;
    }

    public List<Product> GetAll()
    {
        try
        {
            var response = _client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
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

    public bool Update(Product obj)
    {
        var response = _client.PutAsJsonAsync(URL, obj).Result;
        return response.IsSuccessStatusCode;
    }
}