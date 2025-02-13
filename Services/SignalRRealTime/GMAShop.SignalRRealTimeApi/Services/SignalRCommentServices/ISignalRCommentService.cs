namespace GMAShop.SignalRRealTimeApi.Services.SignalRCommentServices;

public interface ISignalRCommentService
{
    Task<int> GetTotalCommentCount();
}