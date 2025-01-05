﻿using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace GMAShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOderingService;
        private readonly IUserService _userService;
        public MyOrderController(IOrderOrderingService orderOderingService, IUserService userService)
        {
            _orderOderingService = orderOderingService;
            _userService = userService;
        }
        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderOderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}
