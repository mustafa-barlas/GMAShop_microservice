﻿using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}