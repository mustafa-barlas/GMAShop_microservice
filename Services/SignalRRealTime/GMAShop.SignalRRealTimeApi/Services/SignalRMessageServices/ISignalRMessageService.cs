namespace GMAShop.SignalRRealTimeApi.Services.SignalRMessageServices;

public interface ISignalRMessageService
{
    Task<int> GetTotalMessageCountByReceiverId(string id);
}