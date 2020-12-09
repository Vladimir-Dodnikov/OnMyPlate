namespace OnMyPlate.Data.Models.Places
{
    using OnMyPlate.Data.Common.Models;

    public class Music : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
