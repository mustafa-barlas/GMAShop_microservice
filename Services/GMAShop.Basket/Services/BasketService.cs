using System.Text.Json;
using GMAShop.Basket.Dtos;
using GMAShop.Basket.Settings;


namespace GMAShop.Basket.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;

    public BasketService(RedisService redisService)
    {
        _redisService = redisService ?? throw new ArgumentNullException(nameof(redisService));
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty", nameof(userId));
        }

        try
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            return existBasket.HasValue ? JsonSerializer.Deserialize<BasketTotalDto>(existBasket) : null;
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error retrieving basket for user {userId}: {ex.Message}");
            throw;
        }
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        if (basketTotalDto == null)
        {
            throw new ArgumentNullException(nameof(basketTotalDto));
        }

        if (string.IsNullOrEmpty(basketTotalDto.UserId))
        {
            throw new ArgumentException("User ID cannot be null or empty", nameof(basketTotalDto.UserId));
        }

        try
        {
            var redisValue = JsonSerializer.Serialize(basketTotalDto);
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, redisValue);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error saving basket for user {basketTotalDto.UserId}: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteBasket(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("User ID cannot be null or empty", nameof(userId));
        }

        try
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error deleting basket for user {userId}: {ex.Message}");
            throw;
        }
    }
}