using Models;

namespace RESTful_API.Repositories.CustomerDA;

public interface ICustomerDA : ICRUD<Customer>
{
    Task<Customer?> GetByEmail(string email);

    Task<bool> CheckEmailExists(string email);
}