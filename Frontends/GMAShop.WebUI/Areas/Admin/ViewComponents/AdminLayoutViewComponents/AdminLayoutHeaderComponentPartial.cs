﻿using GMAShop.WebUI.Services.CommentServices;
using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutHeaderComponentPartial : ViewComponent
{
    private readonly IMessageService _messageService;
    private readonly IUserService _userService;
    private readonly ICommentService _commentService;
    public AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
    {
        _messageService = messageService;
        _userService = userService;
        _commentService = commentService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.GetUserInfo();
        int messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
        ViewBag.messageCount = messageCount;

        int totalCommentcount = await _commentService.GetTotalCommentCount();
        ViewBag.totalCommentCount = totalCommentcount;

        return View();
    }
}