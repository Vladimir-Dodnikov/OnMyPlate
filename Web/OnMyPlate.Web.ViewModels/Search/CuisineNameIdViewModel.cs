namespace OnMyPlate.Web.ViewModels.Search
{
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    public class CuisineNameIdViewModel : IMapFrom<Cuisine>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
