namespace OnMyPlate.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;
    using OnMyPlate.Web.ViewModels.Places;

    public class IndexPagePlaceViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebUrl { get; set; }

        public LocationViewModel Location { get; set; }

        public AddressViewModel Address { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CuisinesViewModel> Cuisines { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Place, IndexPagePlaceViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
