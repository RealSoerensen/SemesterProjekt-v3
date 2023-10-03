using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";
        public string Country { get; set; } = "";

        public Address(long id, string street, string city, string state, string zip, string country)
        {
            Id = id;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }

        [JsonConstructor]
        public Address(string street, string city, string state, string zip, string country)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }
    }
}
