using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.DiscountDtos
{
    public record GetDiscountCodeDetailByCode
    {
        public int CouponId { get; init; }
        public string Code { get; init; }
        public int Rate { get; init; }
        public bool IsActive { get; init; }
        public DateTime ValidDate { get; init; }
    }
}
