using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CatalogDtos.FeatureSliderDtos
{
    public record CreateFeatureSliderDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public bool Status { get; set; }
    }
}
