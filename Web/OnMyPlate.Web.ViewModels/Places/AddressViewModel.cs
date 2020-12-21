namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;

    public class AddressViewModel : IMapFrom<Address>
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int PlaceId { get; set; }
    }
}
