using FoodEstablishment.Infrastructure.Models.Orders;
using System.Threading.Tasks;

namespace FoodEstablishment.Infrastructure.Daos.Interfaces
{
    public interface IOrderLogDao
    {
        public OrderLog Add(OrderLog orderLog);
        public Task<OrderLog> AddAsync(OrderLog orderLog);
    }
}
