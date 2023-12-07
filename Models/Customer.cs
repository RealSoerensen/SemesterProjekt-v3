using Newtonsoft.Json;

namespace Models;

public class Customer
{
    public long ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? AddressID { get; set; }
    public string PhoneNo { get; set; }

    [JsonConstructor]
    public Customer(string firstName, string lastName, string phoneNo)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNo = phoneNo;
    }

    public Customer(long id, string firstName, string lastName, long addressID, string phoneNo)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        AddressID = addressID;
        PhoneNo = phoneNo;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}