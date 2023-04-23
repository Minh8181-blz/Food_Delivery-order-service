using FoodEstablishment.Infrastructure.ElasticSearch;
using Microsoft.Extensions.DependencyInjection;

namespace FoodEstablishment.Infrastructure.DependencyRegistrations
{
    public static class ElasticSearchClientRegistrator
    {
        public static void AddEsClientService(
            this IServiceCollection services,
            string connectionString,
            string username,
            string password)
        {
            services.AddSingleton(EsConnectionConfig.InitBasicAuthConnection(connectionString, username, password));
        }
    }
}
