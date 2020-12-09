namespace OnMyPlate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Cuisine : BaseDeletableModel<int>
    {
        // [Required]
        // [MaxLength(GlobalConstants.CuisineMaxLength)]
        public string Name { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
