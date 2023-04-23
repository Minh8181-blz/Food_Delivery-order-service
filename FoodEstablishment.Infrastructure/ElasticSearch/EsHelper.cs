using FoodEstablishment.Application.Dtos.Base;

namespace FoodEstablishment.Infrastructure.ElasticSearch
{
    internal static class EsHelper
    {
        public static int CalculateQueryFrom(PaginationQueryModel model)
        {
            var result = (model.Page - 1) * model.Size;
            return result;
        }
    }
}
