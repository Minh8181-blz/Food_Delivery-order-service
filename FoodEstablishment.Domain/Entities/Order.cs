using Base.Domain;
using FoodEstablishment.Domain.DomainEvents.Orders;
using FoodEstablishment.Domain.OrderStatuses;
using System;

namespace FoodEstablishment.Domain.Entities
{
    public class Order : Entity<long>, IAggregateRoot
    {
        public static Order CreateReadyForShipOrder(
            long customerId,
            long establishmentId,
            decimal fromLatitude,
            decimal fromLongitude,
            string fromAddress,
            string note,
            string receiverName,
            string receiverPhoneNumber,
            decimal shippingLatitude,
            decimal shippingLongitude,
            string shippingAddress
        ) {
            var order = new Order
            {
                CustomerId = customerId,
                EstablishmentId = establishmentId,
                FromLatitude = fromLatitude,
                FromLongitude = fromLongitude,
                FromAddress = fromAddress,
                TotalAmount = 50000,  // todo: cái này phải tính lại nếu làm thật
                Note = note,
                ReceiverName = receiverName,
                ReceiverPhoneNumber = receiverPhoneNumber,
                ShippingLatitude = shippingLatitude,
                ShippingLongitude = shippingLongitude,
                ShippingAddress = shippingAddress,
                PlacementStatus = OrderPlacementStatus.PLACED,
                AcceptanceStatus = OrderAcceptanceStatus.ACCEPTED,
                ShippingStatus = OrderShippingStatus.UNSHIPPED,
                PaymentStatus = OrderPaymentStatus.UNPAID,
                ExpectedDeliveryAt = DateTime.UtcNow.AddMinutes(30),    // todo: tính lại cái
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
            };

            order.AddDomainEvent(new OrderPlacedDomainEvent(order));

            return order;
        }

        public long CustomerId { get; private set; }
        public long EstablishmentId { get; private set; }
        public decimal FromLatitude { get; private set; }
        public decimal FromLongitude { get; private set; }
        public string FromAddress { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Note { get; private set; }
        public OrderPlacementStatus PlacementStatus { get; private set; }
        public DateTime? ExpectedDeliveryAt { get; private set; }
        public OrderAcceptanceStatus AcceptanceStatus { get; private set; }
        public OrderPaymentStatus PaymentStatus { get; private set; }
        public OrderShippingStatus ShippingStatus { get; private set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public decimal ShippingLatitude { get; private set; }
        public decimal ShippingLongitude { get; private set; }
        public string ShippingAddress { get; private set; }
        // todo: bổ sung các nghiệp vụ khác vào đây (order line items, payment)
    }
}
