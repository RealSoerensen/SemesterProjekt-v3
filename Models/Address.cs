namespace Models;

public class Address
{
    public long? Id { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string Zip { get; private set; }
    public string HouseNumber { get; private set; }

    public Address(long id, string street, string city, string zip, string houseNumber)
    {
        Id = id;
        Street = street;
        City = city;
        Zip = zip;
        HouseNumber = houseNumber;
    }

    public Address(string street, string city, string zip, string houseNumber)
    {
        Street = street;
        City = city;
        Zip = zip;
        HouseNumber = houseNumber;
    }
}