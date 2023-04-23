using FoodEstablishment.Application.Dtos.Base;

namespace FoodEstablishment.Application.Dtos.FoodEstablishments
{
    public class FoodEstablishmentFilterModel : PaginationQueryModel
    {
        public FoodEstablishmentFilterModel() : base()
        {
            OriginLat = DefaultValues.OriginLat;
            OriginLng = DefaultValues.OriginLng;
            RadiusInKm = DefaultValues.FilterRadiusInKm;
        }

        public string Keyword { get; set; }
        public decimal OriginLat { get; set; }
        public decimal OriginLng { get; set; }
        public decimal RadiusInKm { get; set; }

        public override string ToString()
        {
            return $"Page={Page}, Keyword={Keyword}, OriginLat={OriginLat}, OriginLng={OriginLng}, RadiusInKm={RadiusInKm}";
        }
    }
}
