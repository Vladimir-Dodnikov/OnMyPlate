namespace OnMyPlate.Data.Models.Places
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Location : BaseDeletableModel<int>
    {
        // [Required]
        // [MaxLength(GlobalConstants.LocationMaxLength)]
        public string Lattitude { get; set; }

        // [Required]
        // [MaxLength(GlobalConstants.LocationMaxLength)]
        public string Longtitude { get; set; }

        public string GoogleAddress { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
