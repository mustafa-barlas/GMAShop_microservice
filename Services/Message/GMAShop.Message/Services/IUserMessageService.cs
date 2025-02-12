using GMAShop.Message.Dal.Entities;
using GMAShop.Message.Dtos;

namespace GMAShop.Message.Services;

public interface IUserMessageService
{
    Task<List<ResultMessageDto>> GetAllMessageAsync();
    Task<List<ResultInBoxMessageDto>> GetInBoxMessageAsync(string id);
    Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id);
    Task CreateMessageAsync(CreateMessageDto createMessageDto);
    Task UpdateMessageAsync(ResultMessageDto resultMessageDto);
    Task DeleteMessageAsync(int id);
    Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    Task<int> GetTotalMessageCountAsync();
    Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
}