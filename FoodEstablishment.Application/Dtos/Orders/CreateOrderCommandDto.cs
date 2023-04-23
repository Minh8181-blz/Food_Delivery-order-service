using System;

namespace FoodEstablishment.Application.Dtos.Orders
{
    public class CreateOrderCommandDto
    {
        public long CustomerId { get; set; }
        public long EstablishmentId { get; set; }
        public decimal FromLatitude { get; set; }
        public decimal FromLongitude { get; set; }
        public string FromAddress { get; set; }
        public string Note { get; set; }
        public DateTime? ExpectedDeliveryAt { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public decimal ShippingLatitude { get; set; }
        public decimal ShippingLongitude { get; set; }
        public string ShippingAddress { get; set; }
    }
}
