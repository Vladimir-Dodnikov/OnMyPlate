namespace OnMyPlate.Web.ViewModels.Places
{
    using AutoMapper;
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;
    using OnMyPlate.Web.ViewModels.Comments;

    public class LogoImageViewModel : IMapFrom<LogoImage>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public int PlaceId { get; set; }

        public PlaceViewModel Place { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public AuthorViewModel Author { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<LogoImage, LogoImageViewModel>()
                .ForMember(x => x.RemoteImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.RemoteImageUrl != null ?
                        x.RemoteImageUrl :
                        "/images/places/" + x.Id + "." + x.Extension));
        }
    }
}
