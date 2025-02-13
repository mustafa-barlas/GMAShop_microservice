using GMAShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using Microsoft.AspNetCore.SignalR;

namespace GMAShop.SignalRRealTimeApi.Hubs;
public class SignalRHub(ISignalRCommentService signalRCommentService) : Hub
{
    // private readonly ISignalRMessageService _signalRMessageService;

    public async Task SendStatisticCount()
    {
        var getTotalCommentCount = await signalRCommentService.GetTotalCommentCount();
        await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
          
    }
}