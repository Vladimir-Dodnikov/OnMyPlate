namespace OnMyPlate.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPagePlaceViewModel> RandomPlaces { get; set; }

        public int PlacesCount { get; set; }

        public int AmentitiesCount { get; set; }

        public int CuisinesCount { get; set; }

        public int MusicTypesCount { get; set; }

        public int PaymentTypesCount { get; set; }

        public int VotesCount { get; set; }
    }
}
