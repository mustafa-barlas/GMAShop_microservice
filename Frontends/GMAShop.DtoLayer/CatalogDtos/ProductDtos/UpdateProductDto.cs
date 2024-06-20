﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CatalogDtos.ProductDtos
{
    public record UpdateProductDto
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
        public decimal DiscountAmount { get; init; }
        public string ProductImageUrl { get; init; }
        public string ProductDescription { get; init; }
        public string CategoryId { get; init; }
    }
}
