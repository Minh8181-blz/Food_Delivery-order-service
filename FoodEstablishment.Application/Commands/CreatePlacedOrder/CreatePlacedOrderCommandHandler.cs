using AutoMapper;
using Base.Application;
using FoodEstablishment.Application.Dtos.Orders;
using FoodEstablishment.Application.EventPublishers;
using FoodEstablishment.Application.Repositories;
using FoodEstablishment.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodEstablishment.Application.Commands.CreatePlacedOrder
{
    public class CreatePlacedOrderCommandHandler : IRequestHandler<CreatePlacedOrderCommand, OrderCreateResultDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderEventPublisher _orderEventPublisher;

        public CreatePlacedOrderCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOrderEventPublisher orderEventPublisher)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderEventPublisher = orderEventPublisher;
        }

        public async Task<OrderCreateResultDto> Handle(CreatePlacedOrderCommand request, CancellationToken cancellationToken)
        {
            var result = new OrderCreateResultDto();
            var commandDto = request.CommandDto;

            if (commandDto == null ||
                commandDto.CustomerId == 0 ||
                commandDto.EstablishmentId == 0)
            {
                result.Code = "bad_command";
                result.Message = "Invalid order data";
                return result;
            }

            var order = Order.CreateReadyForShipOrder(
                customerId: commandDto.CustomerId,
                establishmentId: commandDto.EstablishmentId,
                fromLatitude: commandDto.FromLatitude,
                fromLongitude: commandDto.FromLongitude,
                fromAddress: commandDto.FromAddress,
                note: commandDto.Note,
                receiverName: commandDto.ReceiverName,
                receiverPhoneNumber: commandDto.ReceiverPhoneNumber,
                shippingLatitude: commandDto.ShippingLatitude,
                shippingLongitude: commandDto.ShippingLongitude,
                shippingAddress: commandDto.ShippingAddress);

            //await _unitOfWork.BeginTransactionAsync();
            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveEntitiesAsync();
            //await _unitOfWork.CommitAsync();

            // handle integration event
            _ = Task.Run(async () => {
                await _orderEventPublisher.PublishAsync(order);
            });

            result.Succeeded = true;
            result.Code = "created";
            result.Order = _mapper.Map<OrderDto>(order);

            return result;
        }
    }
}
