using FoodEstablishment.Domain.Entities;

namespace FoodEstablishment.Domain.DomainEvents.Orders
{
    public class OrderPlacedDomainEvent : BaseOrderDomainEvent
    {
        public OrderPlacedDomainEvent(Order order)
        {
            Name = "order_placed";
            Order = order;
        }
    }
}
