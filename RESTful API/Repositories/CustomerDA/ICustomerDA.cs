using Models;

namespace RESTful_API.Repositories.CustomerDA;

public interface ICustomerDA : ICRUD<Customer>
{
    Customer? Get(long id);
    Customer? GetByEmail(string email);

}
