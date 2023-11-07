using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client.DAL
{
    internal class ProductDA : ICRUD<Product>
    {
        private readonly string URL = Connection.BaseURL() + "api/Product";
        private readonly HttpClient _client = new();

        public Product? Create(Product obj)
        {
            var response = _client.PostAsJsonAsync(URL, obj).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<Product>().Result;
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
                return response.Content.ReadFromJsonAsync<Product>().Result;
            }
            return null;
        }

        public List<Product> GetAll()
        {
            var response = _client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadFromJsonAsync<List<Product>>().Result;
                if (result != null)
                    return result;
            }
            return new List<Product>();
        }

        public bool Update(Product obj)
        {
            var response = _client.PutAsJsonAsync(URL, obj).Result;
            return response.IsSuccessStatusCode;
        }
    }
}