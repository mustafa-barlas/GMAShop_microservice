﻿using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.User.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}