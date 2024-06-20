namespace GMAShop.DtoLayer.CatalogDtos.FeatureDtos
{
    public record GetByIdFeatureDto
    {
        public string FeatureId { get; init; }
        public string Title { get; init; }
        public string Icon { get; init; }
    }
}
