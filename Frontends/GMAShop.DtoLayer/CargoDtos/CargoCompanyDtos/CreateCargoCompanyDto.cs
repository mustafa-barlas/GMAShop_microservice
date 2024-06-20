using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAShop.DtoLayer.CargoDtos.CargoCompanyDtos
{
    public record CreateCargoCompanyDto
    {
        public string cargoCompanyName { get; init; }
    }
}
