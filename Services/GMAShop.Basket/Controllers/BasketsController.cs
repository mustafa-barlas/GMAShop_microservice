using GMAShop.Basket.Dtos;
using GMAShop.Basket.LoginServices;
using GMAShop.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BasketsController(IBasketService basketService, ILoginService loginService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMyBasketDetail()
    {
        var values = await basketService.GetBasket(loginService.UserId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = loginService.UserId;
        await basketService.SaveBasket(basketTotalDto);
        return Ok("Oluşturuldu");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await basketService.DeleteBasket(loginService.UserId);
        return Ok("Silindi");
    }
}