namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;

    public class CuisineService : ICuisineService
    {
        private readonly IDeletableEntityRepository<Cuisine> cuisines;

        public CuisineService(IDeletableEntityRepository<Cuisine> cuisines)
        {
            this.cuisines = cuisines;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllCuisineAsKeyValuePairs()
        {

            return this.cuisines.All().Select(x => new
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
