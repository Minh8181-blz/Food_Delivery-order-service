using AutoMapper;
using FoodEstablishment.Domain.Entities;
using FoodEstablishment.Infrastructure.Helpers;
using FoodEstablishment.Infrastructure.Models.Orders;

namespace FoodEstablishment.Infrastructure.AutoMapper.Profiles
{
    public class InfrastructureOrderMappingProfile : Profile
    {
        public InfrastructureOrderMappingProfile()
        {
            CreateMap<Order, OrderWithExtraInfo>()
                .ForMember(
                    d => d.DomainEvents,
                    e => e.MapFrom(o => OrderLogHelper.GenerateCompactDomainEvents(o.GetDomainEvents())
                ));
        }
    }
}
