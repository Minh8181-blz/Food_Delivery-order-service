using FoodEstablishment.Application.Dtos.Base;
using FoodEstablishment.Application.Dtos.FoodEstablishment;
using FoodEstablishment.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodEstablishment.Application.Queries.FilterFoodEstablishments
{
    public class FilterFoodEstablishmentsQueryHandler
        : IRequestHandler<FilterFoodEstablishmentsQuery, PaginationResultModel<FoodEstablishmentDto>>
    {
        private readonly IFoodEstablishmentQueryService _foodEstablishmentQueryService;

        public FilterFoodEstablishmentsQueryHandler(IFoodEstablishmentQueryService foodEstablishmentQueryService)
        {
            _foodEstablishmentQueryService = foodEstablishmentQueryService;
        }

        public async Task<PaginationResultModel<FoodEstablishmentDto>> Handle(FilterFoodEstablishmentsQuery request, CancellationToken cancellationToken)
        {
            return await _foodEstablishmentQueryService.FilterFoodEstablishmentsAsync(request.Model);
        }
    }
}
