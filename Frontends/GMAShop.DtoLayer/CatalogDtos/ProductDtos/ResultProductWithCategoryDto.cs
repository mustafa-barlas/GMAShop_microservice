using GMAShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace GMAShop.DtoLayer.CatalogDtos.ProductDtos
{
    public record ResultProductWithCategoryDto
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
        public decimal DiscountAmount { get; init; }
        public decimal DiscountedPrice { get; init; }
        public string ProductImageUrl { get; init; }
        public string ProductDescription { get; init; }
        public string CategoryId { get; init; }
        public ResultCategoryDto Category { get; init; }
    }
}
