using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.BaseEntity;
using MoneyHunter.Entities.Entities.Implementations;
using MoneyHunter.Entities.Entities.Interfaces;
using MoneyHunter.Entities.Entities.Interfaces.BaseInterfaces;

namespace MoneyHunter.DAL.Repository;

public class EfRepository<T> : IRepository<T> where T : Entity
{
    private readonly AppDbContext _db;

    public EfRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public bool Create(T entity)
    {
        try
        {
            if (entity is ICreateDate)
            { 
                ((ICreateDate)entity).CreateDate = DateTime.Now;
                _db.Set<T>().Add(entity);
            }
            else
                _db.Set<T>().Add(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            if (entity is ISoftDeletable)
            { 
                ((ISoftDeletable)entity).IsDeleted = true;
                ((ISoftDeletable)entity).DeleteDate = DateTime.Now;
            }
            else 
                _db.Set<T>().Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<T> FindAll()
    {
        return _db.Set<T>();
    }

    public T FindById(object?[]? id)
    {
        return _db.Set<T>().Find(id);

    }
    
    public UserEntity? FindByTgId(int id)
    {
        return _db.Set<UserEntity>().FirstOrDefault(x => x.TgId == id);

    }

    public bool Save()
    {
        try
        {
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(T entity)
    {
        try
        {
            if (entity is IUpdateDate)
            {
                ((IUpdateDate) entity).UpdateDate = DateTime.Now;
                _db.Set<T>().Update(entity);
            }
            else 
                _db.Set<T>().Update(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

