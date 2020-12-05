namespace OnMyPlate.Data.Models.Places
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        [Required]
        public string City { get; set; }
        
        [Required]
        public Street Street { get; set; }

        [Required]
        public string Neibhourhood { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
