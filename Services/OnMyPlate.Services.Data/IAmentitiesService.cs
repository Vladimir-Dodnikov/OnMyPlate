namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface IAmentitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAmentitiesAsKeyValuePairs();
    }
}
