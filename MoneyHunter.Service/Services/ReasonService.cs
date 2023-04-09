using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.Implementations;

namespace MoneyHunter.Service.Services;

public class ReasonService
{
    private readonly IRepository<ReasonEntity> _reasonRepository;
    private readonly IRepository<UserEntity> _userRepository;

    public ReasonService(IRepository<ReasonEntity> reasonRepository, IRepository<UserEntity> userRepository)
    {
        _reasonRepository = reasonRepository;
        _userRepository = userRepository;
    }
    
    public Tuple<bool, string> AddReason(string chat_id, string message)
    {
        var userChatId = int.Parse(chat_id);
        try
        {
            var users = _userRepository.FindAll().ToList();
            var findUser = users.FirstOrDefault(x => x.TgId == userChatId && !x.IsDeleted);
            if (findUser == null)
                return new Tuple<bool, string>(false, "User not found");

            var newReason = new ReasonEntity
            {
                Name = message,
                UserEntityId = findUser.Id
            };

            var result = _reasonRepository.Create(newReason);
            if (!result) return new Tuple<bool, string>(false, "_reasonRepository.Create: Error");
            
            var saveResult = _reasonRepository.Save();
            if (!saveResult) return new Tuple<bool, string>(false, "_reasonRepository.Save: Error");
            
            return new Tuple<bool, string>(true, newReason.Id.ToString());

        }
        catch (Exception e)
        {
            return new Tuple<bool, string>(false, e.Message);
        }
        
    }
}