using GMAShop.Message.Dtos;
using GMAShop.Message.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Message.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMessagesController(IUserMessageService userMessageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMessage()
    {
        var values = await userMessageService.GetAllMessageAsync();
        return Ok(values);
    }

    [HttpGet("GetMessageSenBbox")]
    public async Task<IActionResult> GetMessageSendbox(string id)
    {
        var values = await userMessageService.GetSendBoxMessageAsync(id);
        return Ok(values);
    }

    [HttpGet("GetMessageInBox")]
    public async Task<IActionResult> GetMessageInbox(string id)
    {
        var values = await userMessageService.GetInBoxMessageAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
    {
        await userMessageService.CreateMessageAsync(createMessageDto);
        return Ok("Mesaj başarıyla eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMessageAsync(int id)
    {
        await userMessageService.DeleteMessageAsync(id);
        return Ok("Mesaj başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMessageAsync(ResultMessageDto resultMessageDto)
    {
        await userMessageService.UpdateMessageAsync(resultMessageDto);
        return Ok("Mesaj başarıyla güncellendi");
    }

    [HttpGet("GetTotalMessageCount")]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        int values = await userMessageService.GetTotalMessageCountAsync();
        return Ok(values);
    }

    [HttpGet("GetTotalMessageCountByReceiverId")]
    public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
    {
        int values = await userMessageService.GetTotalMessageCountByReceiverIdAsync(id);
        return Ok(values);
    }
}