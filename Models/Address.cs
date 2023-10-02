using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";
        public string Country { get; set; } = "";

        public Address(int id, string street, string city, string state, string zip, string country)
        {
            Id = id;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }
    }
}
