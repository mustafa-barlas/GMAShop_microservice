using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Services.MessageServices;

namespace GMAShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController(IMessageService messageService, IUserService userService) : Controller
    {
        // public async Task<IActionResult> Inbox()
        // {
        //     var user = await userService.GetUserInfo();
        //     var values = await messageService.GetInboxMessageAsync(user.Id);
        //     return View(values);
        // }
        //
        // public async Task<IActionResult> Sendbox()
        // {
        //     var user = await userService.GetUserInfo();
        //     var values = await messageService.GetSendBoxMessageAsync(user.Id);
        //     return View(values);
        // }
    }
}
