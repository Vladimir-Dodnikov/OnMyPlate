namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface IAmentityService
    {
        IEnumerable<KeyValuePair<int, string>> GetAllAmentitiesAsKeyValuePairs();
    }
}
