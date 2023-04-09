using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.Implementations;

namespace MoneyHunter.Service.Services.UserService;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _userRepository;

    public UserService(IRepository<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public Tuple<bool, string> AddUser(string chat_id)
    {
        var userChatId = int.Parse(chat_id);
        
        var users = _userRepository.FindAll().ToList();
        var findUser = users.FirstOrDefault(x => x.TgId == userChatId && !x.IsDeleted);
        if (findUser != null)
        {
            _userRepository.Delete(findUser);
            _userRepository.Save();
        }

        var newUser = new UserEntity()
        {
            Id = Guid.NewGuid(),
            TgId = userChatId,
        };
        var result = _userRepository.Create(newUser);
        if (result)
        {
            _userRepository.Save();
            Console.WriteLine(newUser);
            return new Tuple<bool, string>(true, newUser.Id.ToString());
        }
        
        return new Tuple<bool, string>(false, "_userRepository.Create: Error");
    }
}