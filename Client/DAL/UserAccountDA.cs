using Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.DAL
{
    internal class UserAccountDA
    {
        private readonly string URL = Connection.BaseURL() + "api/UserAccount";
        private readonly HttpClient _client = new();

        public async Task<UserAccount?> Get(long customerId)
        {
            var response = await _client.GetAsync($"{URL}?customerId={customerId}");
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            var userAccount = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserAccount>(userAccount);
        }

        public async Task<bool> Update(UserAccount userAccount)
        {
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(userAccount), Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(URL, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
