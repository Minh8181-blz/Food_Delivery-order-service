using Base.Domain;
using FoodEstablishment.Domain.Entities;

namespace FoodEstablishment.Domain.DomainEvents.Orders
{
    public abstract class BaseOrderDomainEvent : DomainEvent
    {
        public Order Order { get; protected set; }
        public string Name { get; protected set; }
    }
}
