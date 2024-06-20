namespace GMAShop.DtoLayer.CatalogDtos.ContactDtos
{
    public record CreateContactDto
    {
        public string FullName { get; init; }
        public string Email { get; init; }
        public string Subject { get; init; }
        public string Message { get; init; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
