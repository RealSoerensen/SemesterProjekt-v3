namespace RESTful_API.Repositories;

public interface ICRUD<C> where C : class
{
    C Create(C obj);

    C Get(long id);

    List<C> GetAll();

    bool Update(C obj);

    bool Delete(long id);
}