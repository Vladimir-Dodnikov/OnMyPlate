namespace OnMyPlate.Data.Models.Places
{
    using OnMyPlate.Data.Common.Models;

    public class Location : BaseDeletableModel<int>
    {
        public string Lattitude { get; set; }

        public string Longtitude { get; set; }

        public string GoogleAddress { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
