namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models.Places;

    public class MusicService : IMusicService
    {
        private readonly IDeletableEntityRepository<Music> musicTypes;

        public MusicService(IDeletableEntityRepository<Music> musicTypes)
        {
            this.musicTypes = musicTypes;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllMusicTypesAsKeyValuePairs()
        {
            return this.musicTypes.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .GroupBy(x => x.Name)
            .Select(x => x.First())
            .Select(s => new KeyValuePair<string, string>(s.Id.ToString(), s.Name));
        }
    }
}
