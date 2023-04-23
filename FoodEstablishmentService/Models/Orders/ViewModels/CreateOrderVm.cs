using System;
using System.ComponentModel.DataAnnotations;

namespace FoodEstablishmentService.Models.Orders.ViewModels
{
    public class CreateOrderVm
    {
        [Range(1, long.MaxValue)]
        public long EstablishmentId { get; set; }
        [Range(-90, 90)]
        public decimal FromLatitude { get; set; }
        [Range(-180, 180)]
        public decimal FromLongitude { get; set; }
        [Required]
        public string FromAddress { get; set; }
        public string Note { get; set; }
        public DateTime? ExpectedDeliveryAt { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string ReceiverPhoneNumber { get; set; }
        [Range(-90, 90)]
        public decimal ShippingLatitude { get; set; }
        [Range(-180, 180)]
        public decimal ShippingLongitude { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
    }
}
