using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using GMAShop.Cargo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController(ICargoCompanyService cargoCompanyService) : Controller
{
    private readonly ICargoCompanyService _cargoCompanyService = cargoCompanyService;

    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        var values = _cargoCompanyService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyName = createCargoCompanyDto.CargoCompanyName
        };
        _cargoCompanyService.TInsert(cargoCompany);
        return Ok("kargo  şirketi oluşturludu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCompany(int id)
    {
        _cargoCompanyService.TDelete(id);
        return Ok("kargo şirketi silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetByIdCargoCompany(int id)
    {
        var value = _cargoCompanyService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
            CargoCompanyName  = updateCargoCompanyDto.CargoCompanyName,
         
        };

        _cargoCompanyService.TUpdate(cargoCompany);
        return Ok("kargo şirketi güncellendi");
    }
}