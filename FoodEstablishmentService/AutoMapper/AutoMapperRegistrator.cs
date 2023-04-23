using AutoMapper;
using FoodEstablishment.Application.AutoMapper.Profiles;
using FoodEstablishment.Infrastructure.AutoMapper.Profiles;
using FoodEstablishmentService.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace FoodEstablishmentService.AutoMapper
{
    public static class AutoMapperRegistrator
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {

            services.AddByMethod1();
        }

        private static void AddByMethod1(this IServiceCollection services)
        {
            // param là assembly nên điền class gì cũng được, miễn là nó thuộc assembly cần dùng
            services.AddAutoMapper(
                // assembly tầng service
                typeof(ServiceOrderMappingProfile).Assembly,
                // assembly tầng app
                typeof(OrderMappingProfile).Assembly,
                // assembly tầng infra
                typeof(InfrastructureOrderMappingProfile).Assembly
            );
        }

        //private static void AddByMethod2(this IServiceCollection services)
        //{
        //    var config = new MapperConfiguration(cfg => {
        //        cfg.AddProfile<OrderMappingProfile>();
        //    });

        //    services.AddSingleton(config.CreateMapper());
        //}
    }
}
