﻿namespace OnMyPlate.Web.ViewModels.Places
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using OnMyPlate.Common;

    public class CreatePlaceInputModel
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
        [StringLength(30, ErrorMessage = "Please enter a valid web address!", MinimumLength = 8)]
        public string WebUrl { get; set; }

        [Required]
        public double Lattitude { get; set; }

        [Required]
        public double Longtitude { get; set; }

        [DataType(DataType.Url)]
        public string GoogleAddress { get; set; }

        [Required]
        [StringLength(GlobalConstants.CityMaxLength, ErrorMessage ="Name of the city shoulde be between 2 and 30 characte")]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string OpenTime { get; set; }

        [Required]
        public string CloseTime { get; set; }

        public int AmentityId { get; set; }

        public ICollection<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Amentities { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cuisines { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PaymentTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MusicTypes { get; set; }
    }
}