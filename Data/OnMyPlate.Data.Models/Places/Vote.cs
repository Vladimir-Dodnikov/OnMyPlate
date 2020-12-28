namespace OnMyPlate.Data.Models.Places
{
    using OnMyPlate.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
