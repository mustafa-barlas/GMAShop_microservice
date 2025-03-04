using GMAShop.Basket.Dtos;
using GMAShop.Basket.LoginServices;
using GMAShop.Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Basket.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BasketsController(IBasketService basketService, ILoginService loginService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMyBasketDetail()
    {
        var user = User.Claims;
        var values = await basketService.GetBasket(loginService.GetUserId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = loginService.GetUserId;
        await basketService.SaveBasket(basketTotalDto);
        return Ok("Sepetteki değişiklikler kaydedili");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await basketService.DeleteBasket(loginService.GetUserId);
        return Ok("Sepet başarıyla silindi");
    }
}