﻿using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _HeadUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}