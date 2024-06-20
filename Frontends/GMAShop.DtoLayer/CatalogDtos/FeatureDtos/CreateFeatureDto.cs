namespace GMAShop.DtoLayer.CatalogDtos.FeatureDtos
{
    public record CreateFeatureDto
    {
        public string Title { get; init; }
        public string Icon { get; init; }
    }
}
