﻿using GMAShop.Catalog.Dtos.CategoryDtos;

namespace GMAShop.Catalog.Dtos.ProductDtos;

public class ResultProductsWithCategoryDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }
    public ResultCategoryDto Category { get; set; }
}