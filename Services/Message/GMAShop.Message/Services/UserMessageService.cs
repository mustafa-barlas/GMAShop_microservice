using AutoMapper;
using GMAShop.Message.Dal.Context;
using GMAShop.Message.Dal.Entities;
using GMAShop.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Message.Services;

public class UserMessageService(MessageContext messageContext, IMapper mapper) : IUserMessageService
{
    public async Task DeleteMessageAsync(int id)
    {
        var values = await messageContext.UserMessages.FindAsync(id);
        messageContext.UserMessages.Remove(values);
        await messageContext.SaveChangesAsync();
    }

    public async Task<List<ResultMessageDto>> GetAllMessageAsync()
    {
        var values = await messageContext.UserMessages.ToListAsync();
        return mapper.Map<List<ResultMessageDto>>(values);
    }

    public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
    {
        var values = await messageContext.UserMessages.FindAsync(id);
        return mapper.Map<GetByIdMessageDto>(values);
    }

    public async Task<List<ResultInBoxMessageDto>> GetInBoxMessageAsync(string id)
    {
        var values = await messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
        return mapper.Map<List<ResultInBoxMessageDto>>(values);
    }

    public async Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id)
    {
        var values = await messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
        return mapper.Map<List<ResultSendBoxMessageDto>>(values);
    }

    public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
    {
        var value = mapper.Map<UserMessage>(createMessageDto);
        await messageContext.UserMessages.AddAsync(value);
        await messageContext.SaveChangesAsync();
    }

    public async Task<int> GetTotalMessageCountAsync()
    {
        int values = await messageContext.UserMessages.CountAsync();
        return values;
    }

    public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
    {
        var values = await messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
        return values;
    }

    public async Task UpdateMessageAsync(ResultMessageDto resultMessageDto)
    {
        var values = mapper.Map<UserMessage>(resultMessageDto);
        messageContext.UserMessages.Update(values);
        await messageContext.SaveChangesAsync();
    }
}