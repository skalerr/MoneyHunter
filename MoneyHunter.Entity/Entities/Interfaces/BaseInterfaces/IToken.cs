namespace MoneyHunter.Entities.Entities.Interfaces.BaseInterfaces;

public interface IToken
{
    public DateTime TokenCreated { get; set; }
    public DateTime TokenExpires { get; set; }
    public string RefreshToken { get; set; } 

}

public class RefreshToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Expires { get; set; }
}