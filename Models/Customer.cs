namespace Models;

public class Customer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public string? Password { get; set; }

    public Customer()
    {
    }

    public Customer(string? firstName, string? lastName, Address address, string? email, string? phone, string? password)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        PhoneNo = phone;
        Password = password;
    }
}