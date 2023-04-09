namespace MoneyHunter.Entities.Entities.BaseEntity;

public abstract class Entity<T> : Entity 
{
    public T Id { get; set; }
}

public abstract class Entity
{
        
}