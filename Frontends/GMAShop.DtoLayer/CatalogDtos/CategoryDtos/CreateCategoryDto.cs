﻿namespace GMAShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public record CreateCategoryDto
    {
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }
    }
}
