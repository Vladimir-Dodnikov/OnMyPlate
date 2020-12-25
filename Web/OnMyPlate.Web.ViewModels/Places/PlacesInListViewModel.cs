namespace OnMyPlate.Web.ViewModels.Places
{
    using System.Collections.Generic;

    public class PlacesInListViewModel : PagingViewModel
    {
        public IEnumerable<PlaceViewModel> Places { get; set; }
    }
}
