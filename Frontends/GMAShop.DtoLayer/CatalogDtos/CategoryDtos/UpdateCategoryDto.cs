namespace GMAShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public record UpdateCategoryDto
    {
        public string CategoryID { get; init; }
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }

    }
}
