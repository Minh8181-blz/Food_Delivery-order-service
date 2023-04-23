using Elasticsearch.Net;
using Nest;
using System;

namespace FoodEstablishment.Infrastructure.ElasticSearch
{
    public static class EsConnectionConfig
    {
        public static IElasticClient InitBasicAuthConnection(string connectionString, string username, string password)
        {
            var pool = new SingleNodeConnectionPool(new Uri(connectionString));

            var settings = new ConnectionSettings(pool)
                .ServerCertificateValidationCallback((sender, cert, chain, errors) => true)
                .BasicAuthentication(username, password)
                .EnableApiVersioningHeader();

            var client = new ElasticClient(settings);
            return client;
        }
    }
}
