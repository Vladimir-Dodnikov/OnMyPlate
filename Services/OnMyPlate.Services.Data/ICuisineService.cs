namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface ICuisineService
    {
        IEnumerable<KeyValuePair<int, string>> GetAllCuisineAsKeyValuePairs();
    }
}
