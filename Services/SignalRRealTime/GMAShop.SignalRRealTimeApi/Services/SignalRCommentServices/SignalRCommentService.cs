using Newtonsoft.Json;

namespace GMAShop.SignalRRealTimeApi.Services.SignalRCommentServices;

public class SignalRCommentService(IHttpClientFactory httpClientFactory) : ISignalRCommentService
{
    public async Task<int> GetTotalCommentCount()
    {
        var client = httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7075/api/CommentStatistics");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var commentCount = JsonConvert.DeserializeObject<int>(jsonData);
        return commentCount;
    }
}