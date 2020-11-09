namespace OnMyPlate.Data.Models
{
    using OnMyPlate.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class City : BaseDeletableModel<int>
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string StreetName { get; set; }
    }
}
