using FoodEstablishment.Domain.Entities;
using System.Threading.Tasks;

namespace FoodEstablishment.Application.EventPublishers
{
    public interface IOrderEventPublisher
    {
        Task PublishAsync(Order order);
    }
}
