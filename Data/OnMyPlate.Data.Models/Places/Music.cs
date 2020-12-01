namespace OnMyPlate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Places.PlaceEnums;

    public class Music : BaseDeletableModel<int>
    {
        public MusicType MusicType { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
