namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;

    public class VoteViewModel : IMapFrom<Vote>
    {
        public int PlaceId { get; set; }

        public string UserId { get; set; }

        public byte Value { get; set; }
    }
}
