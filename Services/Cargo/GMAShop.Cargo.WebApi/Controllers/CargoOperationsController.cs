using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using GMAShop.Cargo.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController(ICargoOperationService cargoOperationService) : Controller
{
    private readonly ICargoOperationService _cargoOperationService = cargoOperationService;

    [HttpGet]
    public IActionResult CargoOperationList()
    {
        var values = _cargoOperationService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        CargoOperation cargoOperation = new CargoOperation()
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate
        };
        _cargoOperationService.TInsert(cargoOperation);
        return Ok("kargo oluşturludu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoOperation(int id)
    {
        _cargoOperationService.TDelete(id);
        return Ok("kago oluşturludu");
    }

    [HttpGet("{id}")]
    public IActionResult GetByIdCargoOperation(int id)
    {
        var value = _cargoOperationService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        CargoOperation cargoOperation = new CargoOperation()
        {
            CargoOperationId = updateCargoOperationDto.CargoOperationId,
            Barcode = updateCargoOperationDto.Barcode,
            Description = updateCargoOperationDto.Description,
            OperationDate = updateCargoOperationDto.OperationDate
        };
        _cargoOperationService.TUpdate(cargoOperation);
        return Ok("kargo oluşturludu");
    }
}