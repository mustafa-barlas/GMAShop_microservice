using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.BasketDtos
{
    public record BasketItemDto
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public string ProductImageUrl { get; init; }

    }
}
