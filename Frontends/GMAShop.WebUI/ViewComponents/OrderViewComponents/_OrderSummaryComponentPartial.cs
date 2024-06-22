﻿using GMAShop.Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var basketTotal = await _basketService.GetBasket();
            //var basketItems = basketTotal.BasketItems;
            return View();
        }
    }
}
