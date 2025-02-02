using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.CommentServices;
using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Services.MessageServices;

namespace GMAShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial(
        IMessageService messageService,
        IUserService userService,
        ICommentService commentService)
        : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // var user = await userService.GetUserInfo();
            // int messageCount = await messageService.GetTotalMessageCountByReceiverId(user.Id);
            // ViewBag.messageCount = messageCount;
            //
            // int totalCommentcount = await commentService.GetTotalCommentCount();
            // ViewBag.totalCommentCount = totalCommentcount;  
        
            return View();
        }
    }
}
