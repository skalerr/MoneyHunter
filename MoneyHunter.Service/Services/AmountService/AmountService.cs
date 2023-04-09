using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.Implementations;

namespace MoneyHunter.Service.Services.AmountService;

public class AmountService
{
    private readonly IRepository<ReasonEntity> _reasonRepository;
    private readonly IRepository<AmountEntity> _amountRepository;
    private readonly IRepository<UserEntity> _userRepository;

    public AmountService(IRepository<ReasonEntity> reasonRepository, IRepository<UserEntity> userRepository, IRepository<AmountEntity> amountRepository)
    {
        _reasonRepository = reasonRepository;
        _amountRepository = amountRepository;
        _userRepository = userRepository;
    }
}