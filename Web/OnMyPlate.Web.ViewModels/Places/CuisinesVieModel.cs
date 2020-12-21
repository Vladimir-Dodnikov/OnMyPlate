namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    public class CuisinesVieModel : IMapFrom<Cuisine>
    {
        public string Name { get; set; }

        public int PlaceId { get; set; }
    }
}
