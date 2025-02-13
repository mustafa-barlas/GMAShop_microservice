namespace GMAShop.SignalRRealTimeApi.Services.SignalRMessageServices;

public class SignalRMessageService(HttpClient httpClient) : ISignalRMessageService
{
    public async Task<int> GetTotalMessageCountByReceiverId(string id)
    {
        var responseMessage = await httpClient.GetAsync("UserMessage/GetTotalMessageCountByReceiverId?id=" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }
}