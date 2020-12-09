﻿namespace OnMyPlate.Data.Models.Places
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        // [Required]
        // [MaxLength(GlobalConstants.CityNameMaxLength)]
        public string City { get; set; }

        // [Required]
        public string Street { get; set; }

        // [Required]
        // [MaxLength(GlobalConstants.NeighbourhoodMaxLength)]
        public string Neighbourhood { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
