namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Places;

    public class AmentityService : IAmentityService
    {
        private readonly IDeletableEntityRepository<Amentity> amentities;

        public AmentityService(IDeletableEntityRepository<Amentity> amentities)
        {
            this.amentities = amentities;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllAmentitiesAsKeyValuePairs()
        {
            return this.amentities.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .GroupBy(x => x.Name)
            .Select(x => x.First())
            .Select(s => new KeyValuePair<int, string>(s.Id, s.Name));
        }
    }
}
