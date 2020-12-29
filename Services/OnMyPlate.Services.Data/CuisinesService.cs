namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Services.Mapping;

    public class CuisinesService : ICuisinesService
    {
        private readonly IDeletableEntityRepository<Cuisine> cuisinesRepository;
        private readonly IDeletableEntityRepository<Place> placesRepository;

        public CuisinesService(
            IDeletableEntityRepository<Cuisine> cuisinesRepository,
            IDeletableEntityRepository<Place> placesRepository)
        {
            this.cuisinesRepository = cuisinesRepository;
            this.placesRepository = placesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCuisineAsKeyValuePairs()
        {
            return this.cuisinesRepository.All().Select(x => new
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
            return this.cuisinesRepository.All().ToList().GroupBy(x => x.Name).Select(x => x.First()).Count();
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.cuisinesRepository.All()
                .Where(x => x.Place.Id >= 5)
                .OrderByDescending(x => x.PlaceId)
                .To<T>().ToList();
        }
    }
}
