namespace OnMyPlate.Web.ViewModels.Places
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Ganss.XSS;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;
    using OnMyPlate.Web.ViewModels.Comments;
    using OnMyPlate.Web.ViewModels.Comments.Posts;

    public class PlaceViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public double AverageVoting { get; set; }

        public int VisitsCount { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string WebUrl { get; set; }

        public LocationViewModel Location { get; set; }

        public AddressViewModel Address { get; set; }

        public WorkTimeViewModel WorkTime { get; set; }

        public string CreatedByUserId { get; set; }

        public AuthorViewModel Author { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public IEnumerable<LogoImageViewModel> LogoImages { get; set; }

        public IEnumerable<AmentitiesViewModel> Amentities { get; set; }

        public IEnumerable<CuisinesViewModel> Cuisines { get; set; }

        public IEnumerable<PaymentTypesViewModel> PaymentTypes { get; set; }

        public IEnumerable<MusicTypesViewModel> MusicTypes { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Place, PlaceViewModel>()
                .ForMember(x => x.AverageVoting, opt =>
                    opt.MapFrom(x => x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value)));
        }
    }
}
