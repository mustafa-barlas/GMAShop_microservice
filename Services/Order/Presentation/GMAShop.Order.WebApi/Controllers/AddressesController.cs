using GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using GMAShop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;
using GMAShop.Order.Application.Feature.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _addressQueryHandler;
        private readonly GetAddressByIdQueryHandler _addressByIdQueryHandler;
        private readonly CreateAddressHandler _createAddressHandler;
        private readonly UpdateAddressHandler _updateAddressHandler;
        private readonly RemoveAddressHandler _removeAddressHandler;

        public AddressesController(GetAddressQueryHandler addressQueryHandler, GetAddressByIdQueryHandler addressByIdQueryHandler, CreateAddressHandler createAddressHandler, UpdateAddressHandler updateAddressHandler, RemoveAddressHandler removeAddressHandler)
        {
            _addressQueryHandler = addressQueryHandler;
            _addressByIdQueryHandler = addressByIdQueryHandler;
            _createAddressHandler = createAddressHandler;
            _updateAddressHandler = updateAddressHandler;
            _removeAddressHandler = removeAddressHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _addressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var value = await _addressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressHandler.Handle(command);
            return Ok("Address information added");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressHandler.Handle(command);
            return Ok("Address information updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Address information deleted");
        }
    }
}
