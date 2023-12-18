using Models;

namespace Client.Models
{
    internal class CompleteCustomer
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
