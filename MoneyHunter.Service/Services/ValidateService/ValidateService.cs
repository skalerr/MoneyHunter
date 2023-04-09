namespace MoneyHunter.Service.Services.ValidateService;

public class ValidateService : IValidateService
{
    public Tuple<bool, string> Validate(string chatId)
    {
        int id = 0;
        try
        {
            id = int.Parse(chatId);
            return new Tuple<bool, string>(true, chatId);
        }
        catch (Exception e)
        {
            return new Tuple<bool, string>(false, e.Message);
        }

    }
}