namespace RESTful_API.Repositories;

public interface ICRUD<C> where C : class
{
    Task<C> Create(C obj);

    Task<C> Get(long id);

    Task<List<C>> GetAll();

    Task<bool> Update(C obj);

    Task<bool> Delete(long id);
}