﻿using GMAShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace GMAShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService(HttpClient httpClient) : IContactService
    {
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
        }
        public async Task DeleteContactAsync(string id)
        {
            await httpClient.DeleteAsync("contacts?id=" + id);
        }
        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }
        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await httpClient.GetAsync("contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return values;
        }
        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
        }
    }
}
