using Base.Application.Models;

namespace FoodEstablishment.Application.Dtos.Orders
{
    public class OrderCreateResultDto : CommandResultModel
    {
        public OrderDto Order { get; set; }
    }
}
