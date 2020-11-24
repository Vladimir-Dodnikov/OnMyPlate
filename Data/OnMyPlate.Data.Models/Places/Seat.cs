namespace OnMyPlate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Seat : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.SeatCapacity)]
        public int Indoor { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SeatCapacity)]
        public int Outdoor { get; set; }

        [Required]
        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
