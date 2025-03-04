using System.Text.Json;
using GMAShop.DtoLayer.BasketDtos;

namespace GMAShop.WebUI.Services.BasketServices;

public class BasketService(HttpClient httpClient) : IBasketService
{
    public async Task AddBasketItem(BasketItemDto basketItemDto)
    {
        var values = await GetBasket();

        if (values == null)
        {
            values = new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
        }

        if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
        {
            values.BasketItems.Add(basketItemDto);
        }

        await SaveBasket(values);
    }

    public Task DeleteBasket(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        var responseMessage = await httpClient.GetAsync("baskets");

        if (!responseMessage.IsSuccessStatusCode)
        {
            // Hata durumunda boş bir sepet döndür
            return new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
        }

        var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(jsonResponse))
        {
            // Boş yanıt durumunda boş bir sepet döndür
            return new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
        }

        try
        {
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values ?? new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
        }
        catch (JsonException)
        {
            // JSON deserileştirme hatası durumunda boş bir sepet döndür
            return new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
        }
    }

    public async Task<bool> RemoveBasketItem(string productId)
    {
        var values = await GetBasket();

        if (values == null || values.BasketItems == null || !values.BasketItems.Any())
        {
            return false; // Sepet boşsa veya null ise false döndür
        }

        var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);

        if (deletedItem == null)
        {
            return false; // Silinecek öğe bulunamazsa false döndür
        }

        var result = values.BasketItems.Remove(deletedItem);
        await SaveBasket(values);
        return result;
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        if (basketTotalDto == null)
        {
            throw new ArgumentNullException(nameof(basketTotalDto), "Sepet bilgisi boş olamaz.");
        }

        await httpClient.PostAsJsonAsync("baskets", basketTotalDto);
    }
}