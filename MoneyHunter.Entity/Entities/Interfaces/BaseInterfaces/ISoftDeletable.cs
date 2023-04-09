namespace MoneyHunter.Entities.Entities.Interfaces.BaseInterfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeleteDate { get; set; }
    }
}
