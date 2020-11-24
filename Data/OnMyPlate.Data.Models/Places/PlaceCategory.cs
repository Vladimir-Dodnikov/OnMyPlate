namespace OnMyPlate.Data.Models.Places
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Places.PlaceEnums;

    public class PlaceCategory : BaseDeletableModel<int>
    {
        public PlaceType PlaceType { get; set; }

        [Required]
        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
