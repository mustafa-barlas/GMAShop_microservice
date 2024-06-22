using GMAShop.DtoLayer.CatalogDtos.ContactDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.Contact;

public class ContactService(HttpClient httpClient) : IContactService
{
    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        return await httpClient.GetAndRead<List<ResultContactDto>>("Contacts");
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
       await httpClient.Post("Contacts", createContactDto);
       
    }

    public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
    {
       await httpClient.Put("Contacts", updateContactDto);
       
    }

    public async Task DeleteContactAsync(string id)
    {
        await httpClient.Delete($"Contacts?id={id}");
    }

    public async Task<ResultContactDto> GetByIdContactAsync(string id)
    {
        return await httpClient.GetAndRead<ResultContactDto>($"Contacts/{id}");
    }
}