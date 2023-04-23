using Base.Domain;
using FoodEstablishment.Domain.DomainEvents.Orders;
using FoodEstablishment.Infrastructure.Models.Orders.CompactDomainEvents;
using System.Collections.Generic;
using System.Linq;

namespace FoodEstablishment.Infrastructure.Helpers
{
    public static class OrderLogHelper
    {
        public static IEnumerable<CompactDomainEvent> GenerateCompactDomainEvents(IEnumerable<DomainEvent> orderDomainEvents)
        {
            return orderDomainEvents?.Select(domainEvent =>
            {
                if (domainEvent.GetType() == typeof(OrderPlacedDomainEvent))
                {
                    return new OrderPlacedCompactDomainEvent
                    {
                        Name = (domainEvent as OrderPlacedDomainEvent).Name,
                    };
                }
                else if (domainEvent.GetType() == typeof(BaseOrderDomainEvent))
                {
                    return new CompactDomainEvent
                    {
                        Name = (domainEvent as BaseOrderDomainEvent).Name,
                    };
                }
                return null;
            });
        }
    }
}
