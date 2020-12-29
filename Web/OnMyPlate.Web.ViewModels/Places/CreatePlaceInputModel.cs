namespace OnMyPlate.Web.ViewModels.Places
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using OnMyPlate.Common;

    public class CreatePlaceInputModel : BasePlaceInputModel
    {
        public ICollection<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Amentities { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cuisines { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PaymentTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MusicTypes { get; set; }
    }
}
