using Newtonsoft.Json;

namespace Models;

public class UserAccount
{
    public string Email { get; set; }
    public string Password { get; set; }
    public long CustomerID { get; set; }

    [JsonConstructor]
    public UserAccount(string email, string password, long customerID)
    {
        Email = email;
        Password = password;
        CustomerID = customerID;
    }

    public UserAccount(string email, string password)
    {
        Email = email;
        Password = password;
    }
}