using MoneyHunter.Entities.Entities.Interfaces.BaseInterfaces;

namespace MoneyHunter.Entities.Entities.Interfaces;

public interface IJwt : IPassword, IToken
{
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string RefreshToken { get; set; } 
    public DateTime TokenCreated { get; set; }
    public DateTime TokenExpires { get; set; }
}

