using GMAShop.DtoLayer.CatalogDtos.ContactDtos;
using GMAShop.WebUI.Services.CatalogServices.Contact;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers
{
    public class ContactController(IContactService contactService) : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "GMAShop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Mesaj Gönder";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            await contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Default");
        }
    }
}