using Models;
using System.Text.Json.Serialization;

namespace API.Models;

public class Customer
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }

    [JsonConstructor]
    public Customer(int id, string firstName, string lastName, Address address, string email, string? phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        Phone = phone;
    }

    public Customer(string firstName, string lastName, Address address, string email, string? phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        Phone = phone;
    }
}