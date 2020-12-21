namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        public double Lattitude { get; set; }

        public double Longtitude { get; set; }

        public string GoogleAddress { get; set; }

        public int PlaceId { get; set; }
    }
}
