namespace OnMyPlate.Data.Models.Places
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.CityMaxLength)]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
