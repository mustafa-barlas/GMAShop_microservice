using System.Text.Json;
using GMAShop.Basket.Dtos;
using GMAShop.Basket.Settings;


namespace GMAShop.Basket.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;
    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }
    public async Task DeleteBasket(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }
    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        var existBasket = await _redisService.GetDb().StringGetAsync(userId);
        if (existBasket.IsNullOrEmpty)
        {
            return new BasketTotalDto();
        }
          return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
    }
    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));

    }
}