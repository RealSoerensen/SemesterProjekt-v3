using Models;

namespace RESTful_API.Repositories.OrderDA;

public class OrderDB : ICRUD<Order>
{
    private readonly string _connectionString;

    public OrderDB(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Order Create(Order obj)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Order obj)
    {
        throw new NotImplementedException();
    }

    public Order Get(long id)
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(Order obj)
    {
        throw new NotImplementedException();
    }
}