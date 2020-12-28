namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface IMusicService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllMusicTypesAsKeyValuePairs();

        int GetCounts();
    }
}
