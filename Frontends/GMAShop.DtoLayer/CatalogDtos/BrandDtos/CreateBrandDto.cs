namespace GMAShop.DtoLayer.CatalogDtos.BrandDtos
{
    public record CreateBrandDto
    {
        public string BrandName { get; init; }
        public string ImageUrl { get; init; }
    }
}
