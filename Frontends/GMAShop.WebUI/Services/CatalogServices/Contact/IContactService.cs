using GMAShop.DtoLayer.CatalogDtos.ContactDtos;

namespace GMAShop.WebUI.Services.CatalogServices.Contact;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task UpdateContactAsync(UpdateContactDto updateContactDto);
    Task DeleteContactAsync(string id);
    Task<ResultContactDto> GetByIdContactAsync(string id);
}