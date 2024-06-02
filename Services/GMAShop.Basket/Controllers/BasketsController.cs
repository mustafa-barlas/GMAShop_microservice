using GMAShop.Basket.Dtos;
using GMAShop.Basket.LoginServices;
using GMAShop.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ILoginService _loginService;

    public BasketsController(IBasketService basketService, ILoginService loginService)
    {
        _basketService = basketService;
        _loginService = loginService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyBasketDetail()
    {
        var values = await _basketService.GetBasket(_loginService.UserId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.UserId;
        await _basketService.SaveBasket(basketTotalDto);
        return Ok("Oluşturuldu");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasket(_loginService.UserId);
        return Ok("Silindi");
    }
}