using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public record CreateCategoryDto
    {
        public string CategoryName { get; init; }
        public string ImageUrl { get; init; }
    }
}
