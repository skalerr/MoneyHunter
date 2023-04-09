using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.Implementations;

namespace MoneyHunter.Service.Services.ReasonService;

public class ReasonService : IReasonService
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
            var users = _userRepository.FindAll();
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

    public Tuple<bool, string> AddReasonPrice(string chat_id, string message)
    {
        var userChatId = int.Parse(chat_id);
        try
        {
            var users = _userRepository.FindAll();
            var findUser = users.FirstOrDefault(x => x.TgId == userChatId && !x.IsDeleted);
            if (findUser == null)
                return new Tuple<bool, string>(false, "User not found");

            var reasons = _reasonRepository.FindAll();
            var findReason = reasons.FirstOrDefault(x => x.UserEntityId == findUser.Id && !x.IsDeleted);
            if (findReason == null)
                return new Tuple<bool, string>(false, "Reason not found");

            var price = int.Parse(message);
            findReason.AmountAward = price;
            var result = _reasonRepository.Update(findReason);
            if (!result) return new Tuple<bool, string>(false, "_reasonRepository.Update: Error");
            
            var saveResult = _reasonRepository.Save();
            if (!saveResult) return new Tuple<bool, string>(false, "_reasonRepository.Save: Error");
            
            return new Tuple<bool, string>(true, findReason.Id.ToString());
        }
        catch (Exception e)
        {
            return new Tuple<bool, string>(false, e.Message);
        }
    }

    public Tuple<bool, string> RemoveReason(string chat_id, string message)
    {
        var userChatId = int.Parse(chat_id);
        try
        {
            var users = _userRepository.FindAll();
            var findUser = users.FirstOrDefault(x => x.TgId == userChatId && !x.IsDeleted);
            if (findUser == null)
                return new Tuple<bool, string>(false, "User not found");

            var reasons = _reasonRepository.FindAll();
            var findReason = reasons.FirstOrDefault(x => x.UserEntityId == findUser.Id && !x.IsDeleted);
            if (findReason == null)
                return new Tuple<bool, string>(false, "Reason not found");

            findReason.IsDeleted = true;
            var result = _reasonRepository.Update(findReason);
            if (!result) return new Tuple<bool, string>(false, "_reasonRepository.Update: Error");
            
            var saveResult = _reasonRepository.Save();
            if (!saveResult) return new Tuple<bool, string>(false, "_reasonRepository.Save: Error");
            
            return new Tuple<bool, string>(true, findReason.Id.ToString());
        }
        catch (Exception e)
        {
            return new Tuple<bool, string>(false, e.Message);
        }
    }
}