using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class CustomerDA
{
    private readonly string URL = Connection.BaseURL() + "api/Customer";
    private readonly HttpClient _client = new();

    public async Task<Customer?> Create(Customer obj)
    {
        try
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(URL, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(jsonResponse);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }

    public async Task<bool> Update(Customer obj)
    {
        try
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(URL, content);
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Customer>> GetAll()
    {
        try
        {
            var response = await _client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Customer>>(jsonResponse);

                if (result != null)
                    return result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new List<Customer>();
    }

}