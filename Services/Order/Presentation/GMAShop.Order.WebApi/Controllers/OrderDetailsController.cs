using GMAShop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using GMAShop.Order.Application.Feature.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdCommandHandler _getOrderDetailByIdCommandHandler;
        private readonly GetOrderDetailCommandHandler _getOrderDetailCommand;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailHandler;
        private readonly UpdateOrderDetailQueryHandler _updateOrderDetailHandler;
        private readonly RemoveOrderDetailQueryHandler _removeOrderDetailHandler;

        public OrderDetailsController(RemoveOrderDetailQueryHandler removeOrderDetailHandler, UpdateOrderDetailQueryHandler updateOrderDetailHandler, CreateOrderDetailCommandHandler createOrderDetailHandler, GetOrderDetailByIdCommandHandler getOrderDetailByIdCommandHandler, GetOrderDetailByIdCommandHandler orderDetailQueryHandler, GetOrderDetailCommandHandler getOrderDetailCommand)
        {
            _removeOrderDetailHandler = removeOrderDetailHandler;
            _updateOrderDetailHandler = updateOrderDetailHandler;
            _createOrderDetailHandler = createOrderDetailHandler;
            _getOrderDetailByIdCommandHandler = getOrderDetailByIdCommandHandler;
            _getOrderDetailByIdCommandHandler = orderDetailQueryHandler;
            _getOrderDetailCommand = getOrderDetailCommand;
        }


        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailCommand.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(int id)
        {
            var value = await _getOrderDetailByIdCommandHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailHandler.Handle(command);
            return Ok("OrderDetail information added");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailHandler.Handle(command);
            return Ok("OrderDetail information updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("OrderDetail information deleted");
        }
    }
}
