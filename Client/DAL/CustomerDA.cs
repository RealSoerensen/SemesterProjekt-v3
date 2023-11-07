using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL;

internal class CustomerDA : ICRUD<Customer>
{
    private readonly string URL = Connection.BaseURL() + "api/Customer";
    private readonly HttpClient _client = new();

    public Customer? Create(Customer obj)
    {
        try
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(URL, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
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

    public bool Update(Customer obj)
    {
        try
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var response = _client.PutAsync(URL + "/" + obj.ID, content).Result;
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Customer? Get(long id)
    {
        try
        {
            var response = _client.GetAsync(URL + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
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

    public List<Customer> GetAll()
    {
        try
        {
            var response = _client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
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

    public bool Delete(long id)
    {
        try
        {
            var response = _client.DeleteAsync(URL + "/" + id).Result;
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}