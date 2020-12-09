namespace OnMyPlate.Data.Models.Places
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Payment : BaseDeletableModel<int>
    {
        // [Required]
        // [MaxLength(GlobalConstants.PaymentNameMaxLength)]
        public string Name { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
