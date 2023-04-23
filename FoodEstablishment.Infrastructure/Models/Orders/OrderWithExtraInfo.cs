using Base.Domain;
using FoodEstablishment.Domain.Entities;
using FoodEstablishment.Infrastructure.Models.Orders.CompactDomainEvents;
using System.Collections.Generic;

namespace FoodEstablishment.Infrastructure.Models.Orders
{
    public class OrderWithExtraInfo : Order
    {
        public IReadOnlyCollection<CompactDomainEvent> DomainEvents { get; set; }
    }
}
