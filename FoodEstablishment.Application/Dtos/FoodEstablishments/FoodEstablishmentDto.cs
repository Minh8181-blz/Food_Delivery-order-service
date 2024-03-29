﻿namespace FoodEstablishment.Application.Dtos.FoodEstablishment
{
    public class FoodEstablishmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
    }
}
