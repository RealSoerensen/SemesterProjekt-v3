using API.Models;
using Client.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    internal class CustomerController
    {
        private readonly CustomerDA _customerDA;

        public CustomerController()
        {
            _customerDA = new CustomerDA();
        }

        public Customer? Create(Customer customer)
        {
            return _customerDA.Create(customer);
        }

        public Customer? Get(int id)
        {
            return _customerDA.GetCustomerById(id);
        }

        public List<Customer>? GetAll()
        {
            return _customerDA.GetAllCustomers();
        }

        public bool Update(Customer customer)
        {
            return _customerDA.Update(customer);
        }

        public bool Delete(Customer customer)
        {
            return _customerDA.Delete(customer);
        }
    }
}
