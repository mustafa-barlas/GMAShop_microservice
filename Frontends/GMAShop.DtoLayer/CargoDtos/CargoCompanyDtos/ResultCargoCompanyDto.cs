using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CargoDtos.CargoCompanyDtos
{
    public record ResultCargoCompanyDto
    {
        public int cargoCompanyId { get; init; }
        public string cargoCompanyName { get; init; }
    }
}
