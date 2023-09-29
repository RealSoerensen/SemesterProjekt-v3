namespace API.Models;

public class Customer
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }

    public Customer(int id, string firstName, string lastName, string address, string email, string? phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        Phone = phone;
    }
}