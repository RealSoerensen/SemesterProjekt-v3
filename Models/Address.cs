namespace Models;

public class Address
{
    public long Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }

    public Address()
    {
    }

    public Address(long id, string? street, string? city, string? state, string? zip, string? country)
    {
        Id = id;
        Street = street;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
    }

    public Address(string? street, string? city, string? state, string? zip, string? country)
    {
        Street = street;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
    }
}