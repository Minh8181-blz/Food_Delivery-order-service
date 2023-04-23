
using Base.Domain;
using FoodEstablishment.Domain.Entities;

namespace FoodEstablishment.Application.Repositories
{
    public interface IOrderRepository : IRepository<Order, long>
    {
    }
}
