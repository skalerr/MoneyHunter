namespace MoneyHunter.Entities.Entities.Interfaces
{
    internal interface IConcurrencyToken<T>
    {
        T ConcurrencyToken { get; set; }
    }
}
