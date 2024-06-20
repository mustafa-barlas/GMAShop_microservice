using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.OrderDtos.OrderAddressDtos
{
    public record CreateOrderAddressDto
    {
        public string UserId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string Country { get; init; }
        public string District { get; init; }
        public string City { get; init; }
        public string Detail1 { get; init; }
        public string Detail2 { get; init; }
        public string Description { get; init; }
        public string ZipCode { get; init; }
    }
}
