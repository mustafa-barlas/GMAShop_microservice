
namespace GMAShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService(HttpClient httpClient) : IMessageStatisticService
    {
        public async Task<int> GetTotalMessageCount()
        {
            var responseMessage = await httpClient.GetAsync("UserMessages/GetTotalMessageCountAsync");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
