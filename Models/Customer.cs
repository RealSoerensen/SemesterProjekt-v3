﻿namespace Models;

public class Customer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long AddressId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public string? Password { get; set; }

    public Customer()
    {
    }

    public Customer(string? firstName, string? lastName, long address, string? email, string? phone, string? password)
    {
        FirstName = firstName;
        LastName = lastName;
        AddressId = address;
        Email = email;
        PhoneNo = phone;
        Password = password;
    }
}