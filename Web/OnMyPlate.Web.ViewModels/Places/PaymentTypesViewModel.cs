namespace OnMyPlate.Web.ViewModels.Places
{
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;

    public class PaymentTypesViewModel : IMapFrom<Payment>
    {
        public string Name { get; set; }

        public int PlaceId { get; set; }
    }
}
