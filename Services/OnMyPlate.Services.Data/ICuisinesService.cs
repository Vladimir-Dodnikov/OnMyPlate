namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface ICuisinesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllCuisineAsKeyValuePairs();

        int GetCounts();

        IEnumerable<T> GetAllPopular<T>();
    }
}
