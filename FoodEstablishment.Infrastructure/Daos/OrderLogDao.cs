using FoodEstablishment.Infrastructure.Daos.Interfaces;
using FoodEstablishment.Infrastructure.Database;
using FoodEstablishment.Infrastructure.Models.Orders;
using System.Threading.Tasks;

namespace FoodEstablishment.Infrastructure.Daos
{
    public class OrderLogDao : IOrderLogDao
    {
        private readonly FoodEstablishmentDbContext _dbContext;

        public OrderLogDao(
            FoodEstablishmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderLog Add(OrderLog orderLog)
        {
            return  _dbContext.Add(orderLog).Entity;
        }

        public async Task<OrderLog> AddAsync(OrderLog orderLog)
        {
            return (await _dbContext.AddAsync(orderLog)).Entity;
        }
    }
}
