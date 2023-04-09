namespace MoneyHunter.Service.Services.UserService;

public interface IUserService
{
    Tuple<bool, string> AddUser(string chat_id);
}