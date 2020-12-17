﻿namespace OnMyPlate.Services.Data
{
    using System.Threading.Tasks;

    using OnMyPlate.Web.ViewModels.PlacesViewModel;

    public interface IPlacesService
    {
        Task CreateAsync(CreatePlaceInputModel input, string userId, string[] selectedAmentities, string[] selectedCuisineTypes, string[] selectedMusicTypes, string[] selectedPaymentTypes, string imagePath);
    }
}
