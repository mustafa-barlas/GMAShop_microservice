﻿using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}
