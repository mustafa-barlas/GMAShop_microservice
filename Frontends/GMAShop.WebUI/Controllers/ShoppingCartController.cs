﻿using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}