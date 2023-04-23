using AutoMapper;
using FoodEstablishment.Application.Dtos.Orders;
using FoodEstablishmentService.Models.Orders.ViewModels;

namespace FoodEstablishmentService.AutoMapper.Profiles
{
    public class ServiceOrderMappingProfile : Profile
    {
        public ServiceOrderMappingProfile()
        {
            CreateMap<CreateOrderVm, CreateOrderCommandDto>();
        }
    }
}
