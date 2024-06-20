namespace GMAShop.DtoLayer.CatalogDtos.SpecialOfferDtos
{
    public record GetByIdSpecialOfferDto
    {
        public string SpecialOfferId { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
    }
}
