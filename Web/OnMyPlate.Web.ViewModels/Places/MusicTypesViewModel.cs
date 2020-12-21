namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;

    public class MusicTypesViewModel : IMapFrom<Music>
    {
        public string Name { get; set; }

        public int PlaceId { get; set; }
    }
}
