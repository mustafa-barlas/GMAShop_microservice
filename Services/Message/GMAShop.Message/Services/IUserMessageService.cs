using GMAShop.Message.Dal.Entities;
using GMAShop.Message.Dtos;

namespace GMAShop.Message.Services;

public interface IUserMessageService
{
    Task<List<ResultMessageDto>> GetAllMessageAsync();
    Task<ResultInBoxMessageDto> GetInBoxMessageAsync(string id);
    Task<ResultSendBoxMessageDto> GetSendBoxMessageAsync(string id);
    Task CreateMessageAsync(CreateMessageDto createMessageDto);
    Task DeleteMessageAsync(int id);
    Task<GetByIdMessageDto> GetByIdMessageAsync(int id);

}