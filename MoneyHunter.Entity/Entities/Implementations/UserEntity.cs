using MoneyHunter.Entities.Entities.BaseEntity;
using MoneyHunter.Entities.Entities.Interfaces;

namespace MoneyHunter.Entities.Entities.Implementations;

public class UserEntity : Entity<Guid>, IAuditable
{
    public string Name { get; set; } = string.Empty;
    public int TgId { get; set; } 
    // public List<Reason> Reasons { get; set; } = new();
    
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeleteDate { get; set; } 
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}


