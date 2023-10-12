namespace Models;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long AddressID { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Password { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.Now;

    public Customer(string firstName, string lastName, long addressID, string email, string phoneNo, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        AddressID = addressID;
        Email = email;
        PhoneNo = phoneNo;
        Password = password;
    }

    public Customer(string firstName, string lastName, long addressID, string email, string phoneNo, string password, DateTime registerDate)
    {
        FirstName = firstName;
        LastName = lastName;
        AddressID = addressID;
        Email = email;
        PhoneNo = phoneNo;
        Password = password;
        RegisterDate = registerDate;
    }
}