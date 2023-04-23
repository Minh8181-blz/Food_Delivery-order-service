using AutoMapper;
using FoodEstablishment.Application.Commands.CreatePlacedOrder;
using FoodEstablishment.Application.Dtos.Orders;
using FoodEstablishmentService.Models.Orders.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodEstablishmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Buyer")]
    public class OrdersController : ControllerCustomBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<OrderCreateResultDto> Filter([FromBody] CreateOrderVm model)
        {
            var commandParamModel = _mapper.Map<CreateOrderCommandDto>(model);
            commandParamModel.CustomerId = GetCurrentUserId().Value;
            var command = new CreatePlacedOrderCommand(commandParamModel);
            return await _mediator.Send(command);
        }
    }
}
