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

    public Address(long id, string zip, string houseNumber, string city, string street)
    {
        Id = id;
        Street = street;
        City = city;
        Zip = zip;
        HouseNumber = houseNumber;
    }
}