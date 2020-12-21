namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnMyPlate.Web.ViewModels.Places;

    public interface IPlacesService
    {
        Task CreateAsync(CreatePlaceInputModel input, string userId, string[] selectedAmentities, string[] selectedCuisineTypes, string[] selectedMusicTypes, string[] selectedPaymentTypes, string imagePath);

        T GetById<T>(int id);

        IEnumerable<T> GetPopular<T>();

        IEnumerable<T> GetAll<T>();
    }
}
