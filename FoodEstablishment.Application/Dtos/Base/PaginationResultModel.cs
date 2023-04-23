using System.Collections.Generic;

namespace FoodEstablishment.Application.Dtos.Base
{
    public class PaginationResultModel<T>
    {
        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}
