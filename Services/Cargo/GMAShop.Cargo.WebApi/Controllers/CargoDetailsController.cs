using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using GMAShop.Cargo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService cargoDetailService) : Controller
{
    private readonly ICargoDetailService _cargoDetailService = cargoDetailService;

    [HttpGet]
    public IActionResult CargoDetailList()
    {
        var values = _cargoDetailService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        CargoDetail cargoDetail = new CargoDetail()
        {
            CompanyId = createCargoDetailDto.CargoCompanyId,
            CustomerId = createCargoDetailDto.CargoCustomerId,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            SenderCustomer = createCargoDetailDto.SenderCustomer,
            Barcode = createCargoDetailDto.Barcode,
        };
        _cargoDetailService.TInsert(cargoDetail);
        return Ok("kargo oluşturludu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoDetail(int id)
    {
        _cargoDetailService.TDelete(id);
        return Ok("kago oluşturludu");
    }

    [HttpGet("{id}")]
    public IActionResult GetByIdCargoDetail(int id)
    {
        var value = _cargoDetailService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        CargoDetail cargoDetail = new CargoDetail()
        {
            CargoDetailId = updateCargoDetailDto.CargoDetailId,
            CompanyId = updateCargoDetailDto.CargoCompanyId,
            CustomerId = updateCargoDetailDto.CargoCustomerId,
            ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
            SenderCustomer = updateCargoDetailDto.SenderCustomer,
            Barcode = updateCargoDetailDto.Barcode,
        };
        _cargoDetailService.TUpdate(cargoDetail);
        return Ok("kargo oluşturludu");
    }
}