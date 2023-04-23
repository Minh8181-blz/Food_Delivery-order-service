using Base.Domain;

namespace FoodEstablishment.Domain.Entities
{
    public class FoodEstablishmentEntity : Entity<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
    }
}
