using Base.Application;
using FoodEstablishment.Application.Repositories;
using FoodEstablishment.Infrastructure.Daos;
using FoodEstablishment.Infrastructure.Daos.Interfaces;
using FoodEstablishment.Infrastructure.Database;
using FoodEstablishment.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FoodEstablishment.Infrastructure.DependencyRegistrations
{
    public static class DatabaseAccessRegistrator
    {
        public static void AddDatabaseAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<FoodEstablishmentDbContext>>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderLogDao, OrderLogDao>();
        }
    }
}
