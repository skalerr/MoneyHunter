namespace MoneyHunter.Service.Services.ValidateService;

public interface IValidateService
{
    Tuple<bool, string> Validate(string chatId);
}