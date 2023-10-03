using API.DAL.CustomerDA;
using API.Models;
using Models;
using RESTful_API.DAL.AddressDA;

namespace RESTful_API.Services
{
    public class CustomerService : ICustomer
    {
        private readonly ICustomer _customerDB;
        private readonly IAddress _addressDB;

        public CustomerService(ICustomer customerDB, IAddress addressDB)
        {
            _customerDB = customerDB;
            _addressDB = addressDB;
        }

        public Customer? Create(Customer obj)
        {
            try
            {
                Address? address = _addressDB.Create(obj.Address);

                if (address == null)
                {
                    // Handle the case where Address creation failed
                    return null; // or throw an exception if appropriate
                }

                obj.Address = address;

                Customer? customer = _customerDB.Create(obj);

                if (customer == null)
                {
                    // Handle the case where Customer creation failed
                    // You can also consider rolling back the Address creation here if needed
                    return null; // or throw an exception if appropriate
                }

                return customer;
            }
            catch (Exception ex)
            {
                // Handle the exception and optionally log it
                // You can also consider rolling back the Address creation here if needed
                Console.WriteLine(ex);
                // You can return null or rethrow the exception based on your error handling strategy
                return null; // or throw ex; if you want to rethrow the exception
            }
        }


        public bool Delete(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Customer? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
