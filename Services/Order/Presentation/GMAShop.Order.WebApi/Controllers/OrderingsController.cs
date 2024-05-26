using GMAShop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using GMAShop.Order.Application.Feature.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var result = await mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingListById(int id)
        {

            var result = await mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Ordering information added");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Ordering information updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Ordering information deleted");
        }
    }
}
