namespace OnMyPlate.Web.ViewModels.PlacesViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Microsoft.AspNetCore.Http;
    using OnMyPlate.Common;
    using OnMyPlate.Data.Models.Places;

    public class CreatePlaceInputModel : Image
    {
        [Required]
        [StringLength(GlobalConstants.PlaceNameMaxLength, ErrorMessage ="The Name of the Place should be between 2 and 100 charactes.", MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        [StringLength(GlobalConstants.PlaceDescriptionMaxLength, ErrorMessage = "The Information of the Place should be between 10 and 4000 charactes.", MinimumLength =10)]
        [Display(Name ="Fill-in information about your place")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Choose your logo:")]
        public IFormFile LogoImage { get; set; }

        [Required]
        [Display(Name = "Enter original web address")]
        public string WebUrl { get; set; }

        [Required]
        [StringLength(GlobalConstants.LocationMaxLength, ErrorMessage = "Coordinates shoul be between 5 and 10 integers! example: Latitude: 45.225, Longtitude: 22.548", MinimumLength = 5)]
        public Location Location { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public WorkTime WorkTime { get; set; }

        public virtual ICollection<IFormFile> Images { get; set; }

        public virtual IEnumerable<KeyValuePair<int, string>> Amentities { get; set; }

        public virtual IEnumerable<KeyValuePair<int, string>> Cuisines { get; set; }

        public virtual IEnumerable<KeyValuePair<int, string>> PaymentTypes { get; set; }

        public virtual IEnumerable<KeyValuePair<int, string>> MusicTypes { get; set; }
    }
}
