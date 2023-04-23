using FoodEstablishment.Application.Dtos.Base;
using FoodEstablishment.Application.Dtos.FoodEstablishment;
using FoodEstablishment.Application.Dtos.FoodEstablishments;
using System.Threading.Tasks;

namespace FoodEstablishment.Application.Services
{
    public interface IFoodEstablishmentQueryService
    {
        Task<PaginationResultModel<FoodEstablishmentDto>> FilterFoodEstablishmentsAsync(FoodEstablishmentFilterModel model);
    }
}
