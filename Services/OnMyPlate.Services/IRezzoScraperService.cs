namespace OnMyPlate.Services
{
    using System.Threading.Tasks;

    public interface IRezzoScraperService
    {
        Task ImportPlacesAsync();
    }
}
