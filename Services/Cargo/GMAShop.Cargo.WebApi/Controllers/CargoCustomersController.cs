using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using GMAShop.Cargo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController(ICargoCustomerService cargoCustomerService) : Controller
{
    private readonly ICargoCustomerService _cargoCustomerService = cargoCustomerService;

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        var values = _cargoCustomerService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Name = createCargoCustomerDto.Name,
            Surname = createCargoCustomerDto.Surname,
            Phone = createCargoCustomerDto.Phone,
            Email = createCargoCustomerDto.Email,
            District = createCargoCustomerDto.District,
            Address = createCargoCustomerDto.Address,
            City = createCargoCustomerDto.City,
        };
        _cargoCustomerService.TInsert(cargoCustomer);
        return Ok("müşteri oluşturludu");
    }

    [HttpDelete]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _cargoCustomerService.TDelete(id);
        return Ok("müşteri silindi");
    }

    [HttpGet("{id}")]
    public IActionResult GetByIdCargoCustomer(int id)
    {
        var value = _cargoCustomerService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
            Name = updateCargoCustomerDto.Name,
            Surname = updateCargoCustomerDto.Surname,
            Phone = updateCargoCustomerDto.Phone,
            Email = updateCargoCustomerDto.Email,
            District = updateCargoCustomerDto.District,
            Address = updateCargoCustomerDto.Address,
            City = updateCargoCustomerDto.City,
            
        };
        _cargoCustomerService.TUpdate(cargoCustomer);
        return Ok("müşteri güncellendi");
    }
}