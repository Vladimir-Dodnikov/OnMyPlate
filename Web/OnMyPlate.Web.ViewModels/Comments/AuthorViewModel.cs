namespace OnMyPlate.Web.ViewModels.Comments
{
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    public class AuthorViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }
    }
}
