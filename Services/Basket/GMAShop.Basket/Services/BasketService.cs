using System.Text.Json;
using GMAShop.Basket.Dtos;
using GMAShop.Basket.Settings;


namespace GMAShop.Basket.Services;

public class BasketService(RedisService redisService) : IBasketService
{
    public async Task DeleteBasket(string userId)
    {
        await redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        var existBasket = await redisService.GetDb().StringGetAsync(userId);
        return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
    }
}