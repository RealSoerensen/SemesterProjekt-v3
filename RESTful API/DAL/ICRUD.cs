namespace API.DAL;

public interface ICRUD<C> where C : class
{
    C? Create(C obj);

    C? Get(int id);

    List<C> GetAll();

    bool Update(C obj);

    bool Delete(C obj);
}