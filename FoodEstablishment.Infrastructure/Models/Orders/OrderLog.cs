using System;
using System.ComponentModel.DataAnnotations;

namespace FoodEstablishment.Infrastructure.Models.Orders
{
    public class OrderLog
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
