using GMAShop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using GMAShop.Order.Application.Feature.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var result = await _mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingListById(int id)
        {

            var result = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering information added");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering information updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Ordering information deleted");
        }
    }
}
