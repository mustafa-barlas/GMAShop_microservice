﻿namespace GMAShop.DtoLayer.CatalogDtos.ContactDtos
{
    public record GetByIdContactDto
    {
        public string ContactId { get; init; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
