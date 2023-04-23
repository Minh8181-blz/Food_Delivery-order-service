using AutoMapper;
using FoodEstablishment.Application.Dtos.Orders;
using FoodEstablishment.Domain.Entities;

namespace FoodEstablishment.Application.AutoMapper.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
