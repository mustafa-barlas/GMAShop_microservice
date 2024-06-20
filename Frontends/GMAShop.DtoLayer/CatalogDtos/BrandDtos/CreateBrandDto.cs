using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CatalogDtos.BrandDtos
{
    public record CreateBrandDto
    {
        public string BrandName { get; init; }
        public string ImageUrl { get; init; }
    }
}
