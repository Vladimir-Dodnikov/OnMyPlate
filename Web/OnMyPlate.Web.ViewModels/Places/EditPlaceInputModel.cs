namespace OnMyPlate.Web.ViewModels.Places
{
    using AutoMapper;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    public class EditPlaceInputModel : PlaceViewModel, IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Place, EditPlaceInputModel>()
                .ForMember(x => x.Location, opt =>
                    opt.MapFrom(x => x.Location))
                .ForMember(x => x.WorkTime, opt =>
                    opt.MapFrom(x => x.WorkTime))
                .ForMember(x => x.Address, opt =>
                    opt.MapFrom(x => x.Address));
        }
    }
}
