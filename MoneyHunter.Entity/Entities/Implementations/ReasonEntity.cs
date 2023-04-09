using MoneyHunter.Entities.Entities.BaseEntity;
using MoneyHunter.Entities.Entities.Interfaces;

namespace MoneyHunter.Entities.Entities.Implementations;

public class ReasonEntity :  Entity<Guid>, IAuditable
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? AmountAward { get; set; }
    public decimal? AmountPenalty { get; set; }
    public bool IsPenaltyNullifiesAwards { get; set; } = false;
    
    public Guid UserEntityId { get; set; }
    public UserEntity UserEntity { get; set; }
    
    public bool IsDeleted { get; set; }
    public DateTime? DeleteDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}