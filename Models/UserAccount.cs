using Newtonsoft.Json;

namespace Models;

public class UserAccount
{
    public long ID { get; init; }
    public string Email { get; init; }
    public string Password { get; set; }
    public long CustomerID { get; init; }
    public DateTime RegisterDate { get; init; } = DateTime.UtcNow;

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

    public UserAccount(long id, string email, string password, long customerID)
    {
        ID = id;
        Email = email;
        Password = password;
        CustomerID = customerID;
    }
}