using MoneyHunter.Entities.Entities.BaseEntity;
using MoneyHunter.Entities.Entities.Implementations;

namespace MoneyHunter.DAL.Repository.Interface;

public interface IRepository<T> where T : Entity
{
    public UserEntity? FindByTgId(int id);
    public T FindById(params object?[] id);

    IEnumerable<T> FindAll();

    bool Create (T entity);
        
    bool Update (T entity);

    bool Delete (T entity);

    bool Save();
}