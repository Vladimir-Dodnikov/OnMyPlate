namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;

    public class CuisinesService : ICuisinesService
    {
        private readonly IDeletableEntityRepository<Cuisine> cuisines;

        public CuisinesService(IDeletableEntityRepository<Cuisine> cuisines)
        {
            this.cuisines = cuisines;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCuisineAsKeyValuePairs()
        {
            return this.cuisines.All().Select(x => new
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
            return this.cuisines.All().ToList().GroupBy(x => x.Name).Select(x => x.First()).Count();
        }
    }
}
