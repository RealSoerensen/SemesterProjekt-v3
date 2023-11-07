﻿using Newtonsoft.Json;

namespace Models;

public class Customer
{
    public long? ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? AddressID { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Password { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.Now;

    [JsonConstructor]
    public Customer(string firstName, string lastName, string email, string phoneNo, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNo = phoneNo;
        Password = password;
    }

    public Customer(long id, string firstName, string lastName, long addressID, string email, string phoneNo, string password, DateTime registerDate)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        AddressID = addressID;
        Email = email;
        PhoneNo = phoneNo;
        Password = password;
        RegisterDate = registerDate;
    }
}