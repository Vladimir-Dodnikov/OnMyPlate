namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnMyPlate.Web.ViewModels.Places;

    public interface IPlacesService
    {
        Task CreateAsync(CreatePlaceInputModel input, string userId, string[] selectedAmentities, string[] selectedCuisineTypes, string[] selectedMusicTypes, string[] selectedPaymentTypes, string imagePath);

        Task UpdateAsync(int id, PlaceViewModel input);

        Task DeleteAsync(int id);

        T GetById<T>(int id);

        int GetCount();

        IEnumerable<T> GetRandom<T>(int count);

        IEnumerable<T> GetAllPopular<T>();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetByCusines<T>(IEnumerable<string> cuisines);
    }
}
