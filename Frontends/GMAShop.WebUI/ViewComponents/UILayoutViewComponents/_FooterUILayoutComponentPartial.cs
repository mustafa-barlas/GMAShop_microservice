﻿
using GMAShop.WebUI.Services.CatalogServices.About;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        public _FooterUILayoutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
