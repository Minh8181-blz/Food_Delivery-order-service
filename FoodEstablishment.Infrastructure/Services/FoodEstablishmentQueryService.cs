using FoodEstablishment.Application.Dtos.Base;
using FoodEstablishment.Application.Dtos.FoodEstablishment;
using FoodEstablishment.Application.Dtos.FoodEstablishments;
using FoodEstablishment.Application.Services;
using FoodEstablishment.Infrastructure.ElasticSearch;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEstablishment.Infrastructure.Services
{
    public class FoodEstablishmentQueryService : IFoodEstablishmentQueryService
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<FoodEstablishmentQueryService> _logger;

        public FoodEstablishmentQueryService(IElasticClient elasticClient, ILogger<FoodEstablishmentQueryService> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public async Task<PaginationResultModel<FoodEstablishmentDto>> FilterFoodEstablishmentsAsync(FoodEstablishmentFilterModel model)
        {
            var result = new PaginationResultModel<FoodEstablishmentDto>();
            var from = EsHelper.CalculateQueryFrom(model);

            try
            {
                var searchResponse = await _elasticClient.SearchAsync<FoodEstablishmentDto>(s => s
                    .Index(EsIndexName.FoodEstablishment)
                    .From(from)
                    .Size(model.Size)
                    .Query(q => q
                        .Bool(b => b
                            .Filter(x => x
                                .GeoDistance(g => g
                                    .DistanceType(GeoDistanceType.Arc)
                                    .Field("coordinate")
                                    .Location(new GeoLocation(Convert.ToDouble(model.OriginLat), Convert.ToDouble(model.OriginLng)))
                                    .Distance(string.Format("{0}km", model.RadiusInKm))
                                    //.ValidationMethod(GeoValidationMethod.IgnoreMalformed)
                                )
                            )
                        )
                    )
                );

                result.Data = searchResponse.Documents.ToList();
                result.Page = model.Page;
                result.Total = Convert.ToInt32(searchResponse.Total);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error when filtering food establishment. Model: {model}", model);
            }
            
            return result;
        }
    }
}
