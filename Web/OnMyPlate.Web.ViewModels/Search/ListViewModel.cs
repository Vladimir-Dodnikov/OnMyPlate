namespace OnMyPlate.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using OnMyPlate.Web.ViewModels.Places;

    public class ListViewModel
    {
        public IEnumerable<PlaceViewModel> Places { get; set; }
    }
}
