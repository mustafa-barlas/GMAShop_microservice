using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using GMAShop.WebUI.Services.CatalogServices.AboutServices;

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
