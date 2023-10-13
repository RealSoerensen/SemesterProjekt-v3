using System.Text.Json.Serialization;

namespace Models;

public class Address
{
    public long? Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string HouseNumber { get; set; }

    public Address(string street, string city, string zip, string houseNumber)
    {
        Street = street;
        City = city;
        Zip = zip;
        HouseNumber = houseNumber;
    }

    [JsonConstructor]
    public Address(long id, string street, string city, string zip, string houseNumber)
    {
        Id = id;
        Street = street;
        City = city;
        Zip = zip;
        HouseNumber = houseNumber;
    }
}