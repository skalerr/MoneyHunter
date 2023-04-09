namespace MoneyHunter.Service.Services.ReasonService;

public interface IReasonService
{
    Tuple<bool, string> AddReason(string chat_id, string message);
    Tuple<bool, string> AddReasonPrice(string chat_id, string message);
}