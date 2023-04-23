using FoodEstablishment.Application.Dtos.Base;
using FoodEstablishment.Application.Dtos.FoodEstablishment;
using FoodEstablishment.Application.Dtos.FoodEstablishments;
using MediatR;

namespace FoodEstablishment.Application.Queries.FilterFoodEstablishments
{
    public class FilterFoodEstablishmentsQuery : IRequest<PaginationResultModel<FoodEstablishmentDto>>
    {
        public FilterFoodEstablishmentsQuery(FoodEstablishmentFilterModel model)
        {
            Model = model;
        }

        public FoodEstablishmentFilterModel Model { get; set; }
    }
}
