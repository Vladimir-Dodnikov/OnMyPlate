﻿namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    public class CuisinesViewModel : IMapFrom<Cuisine>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PlaceId { get; set; }
    }
}
