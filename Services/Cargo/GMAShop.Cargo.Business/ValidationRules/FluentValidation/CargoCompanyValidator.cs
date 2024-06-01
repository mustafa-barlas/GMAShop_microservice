using FluentValidation;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.Business.ValidationRules.FluentValidation;

public class CargoCompanyValidator : AbstractValidator<CargoCompany>
{
    public CargoCompanyValidator()
    {
        
    }
}