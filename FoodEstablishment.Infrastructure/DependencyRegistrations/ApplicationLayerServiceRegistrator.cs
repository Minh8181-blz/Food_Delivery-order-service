using FoodEstablishment.Application.EventPublishers;
using FoodEstablishment.Application.Queries.FilterFoodEstablishments;
using FoodEstablishment.Application.Services;
using FoodEstablishment.Infrastructure.EventPublishers;
using FoodEstablishment.Infrastructure.EventPublishers.Models;
using FoodEstablishment.Infrastructure.Kafka.ConfigModels;
using FoodEstablishment.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FoodEstablishment.Infrastructure.DependencyRegistrations
{
    public static class ApplicationLayerServiceRegistrator
    {
        public static void AddApplicationLayerDelegateServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(FilterFoodEstablishmentsQuery).Assembly, typeof(ApplicationLayerServiceRegistrator).Assembly);
            services.AddTransient<IFoodEstablishmentQueryService, FoodEstablishmentQueryService>();
            services.AddSingleton<IOrderEventPublisher, OrderEventPublisher>();
        }

        public static void AddKafkaEventPublisherConfig
            (this IServiceCollection services,
            KafkaEventPublisherConfigModel configModel)
        {
            var orderLogProducerConfigModel = new OrderLogProducerConfigModel(configModel.Config)
            {
                Topic = configModel.TopicMapping["Order"]
            };
            services.AddSingleton(configModel);
            services.AddSingleton(orderLogProducerConfigModel);
        }
    }
}
