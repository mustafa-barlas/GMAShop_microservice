using GMAShop.DtoLayer.DiscountDtos;

namespace GMAShop.WebUI.Services.DiscountServices
{
    public class DiscountService(HttpClient httpClient) : IDiscountService
    {
        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await httpClient.GetAsync("http://localhost:7071/api/Discounts/GetCodeDetailByCodeAsync?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var responseMessage = await httpClient.GetAsync("http://localhost:7071/api/Discounts/GetDiscountCouponCountRate?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
