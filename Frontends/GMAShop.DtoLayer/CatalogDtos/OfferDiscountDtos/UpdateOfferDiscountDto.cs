namespace GMAShop.DtoLayer.CatalogDtos.OfferDiscountDtos
{
    public record UpdateOfferDiscountDto
    {
        public string OfferDiscountId { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
        public string ButtonTitle { get; init; }
    }
}
