namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Places;

    public class AmentitiesService : IAmentitiesService
    {
        private readonly IDeletableEntityRepository<Amentity> amentities;

        public AmentitiesService(IDeletableEntityRepository<Amentity> amentities)
        {
            this.amentities = amentities;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAmentitiesAsKeyValuePairs()
        {
            return this.amentities.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .GroupBy(x => x.Name)
            .Select(x => x.First())
            .Select(s => new KeyValuePair<string, string>(s.Id.ToString(), s.Name));
        }

        public int GetCounts()
        {
            return this.amentities.All().ToList().GroupBy(x => x.Name).Select(x => x.First()).Count();
        }
    }
}
