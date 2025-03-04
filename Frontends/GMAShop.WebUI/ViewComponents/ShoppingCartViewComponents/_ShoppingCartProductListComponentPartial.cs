using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.BasketServices;

namespace GMAShop.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartProductListComponentPartial(IBasketService basketService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var basketTotal = await basketService.GetBasket();
        var basketItems = basketTotal.BasketItems;
        return View(basketItems);
    }
}