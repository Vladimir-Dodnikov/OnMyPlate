namespace OnMyPlate.Web.ViewModels.Settings
{
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    using AutoMapper;

    public class SettingViewModel : IMapFrom<City>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string NameAndValue { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, SettingViewModel>().ForMember(
                m => m.NameAndValue,
                opt => opt.MapFrom(x => x.Name + " = " + x.Value));
        }
    }
}
