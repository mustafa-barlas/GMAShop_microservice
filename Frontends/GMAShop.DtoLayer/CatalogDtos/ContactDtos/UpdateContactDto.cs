namespace GMAShop.DtoLayer.CatalogDtos.ContactDtos
{
    public record UpdateContactDto
    {
        public string ContactId { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public string Subject { get; init; }
        public string Message { get; init; }
        public bool IsRead { get; init; }
        public DateTime SendDate { get; init; }
    }
}
