using FoodEstablishment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodEstablishment.Infrastructure.DependencyRegistrations
{
    public static class DbContextRegistrator
    {
        public static void AddSqlServerDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FoodEstablishmentDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
