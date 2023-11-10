using Models;

namespace RESTful_API.Repositories.CustomerDA;

public interface ICustomerDA : ICRUD<Customer>
{
    Customer? GetByEmail(string email);

    bool CheckEmailExists(string email);
}