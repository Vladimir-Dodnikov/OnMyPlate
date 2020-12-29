namespace OnMyPlate.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using OnMyPlate.Web.ViewModels.Places;

    public class SearchIndexViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> Cuisines { get; set; }
    }
}
