using System.Text.Json.Serialization;

namespace Models;

public class Address
{
    public long? Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string HouseNumber { get; set; }

    public Address()
    {
    }
}