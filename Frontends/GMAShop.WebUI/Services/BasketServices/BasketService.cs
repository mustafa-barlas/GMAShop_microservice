using GMAShop.DtoLayer.BasketDtos;

namespace GMAShop.WebUI.Services.BasketServices
{
    public class BasketService(HttpClient httpClient) : IBasketService
    {
        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var basket = await GetBasket() ?? new BasketTotalDto();

            if (!basket.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                basket.BasketItems.Add(basketItemDto);
            }

            await SaveBasket(basket);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var responseMessage = await httpClient.GetAsync("baskets");
            return await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>() ?? new BasketTotalDto();
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}