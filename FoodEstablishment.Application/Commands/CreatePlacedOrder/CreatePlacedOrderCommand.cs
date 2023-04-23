using FoodEstablishment.Application.Dtos.Orders;
using MediatR;

namespace FoodEstablishment.Application.Commands.CreatePlacedOrder
{
    public class CreatePlacedOrderCommand : IRequest<OrderCreateResultDto>
    {
        public CreatePlacedOrderCommand(CreateOrderCommandDto dto)
        {
            CommandDto = dto;
        }

        public CreateOrderCommandDto CommandDto { get; set; }
    }
}
