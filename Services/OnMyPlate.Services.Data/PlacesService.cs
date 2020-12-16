namespace OnMyPlate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Web.ViewModels.PlacesViewModel;

    public class PlacesService : IPlacesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Place> placesRepository;
        private readonly IDeletableEntityRepository<Location> locationsRepository;
        private readonly IDeletableEntityRepository<Address> addressesRepository;
        private readonly IRepository<Image> imagesRepository;
        private readonly IRepository<LogoImage> logoImagesRepository;
        private readonly IDeletableEntityRepository<WorkTime> workTimesRepository;
        private readonly IDeletableEntityRepository<Amentity> amentitiesRepository;
        private readonly IDeletableEntityRepository<Cuisine> cuisinesRepository;
        private readonly IDeletableEntityRepository<Payment> paymentsRepository;
        private readonly IDeletableEntityRepository<Music> musicRepository;

        public PlacesService(
            IDeletableEntityRepository<Place> placesRepository,
            IDeletableEntityRepository<Location> locationsRepository,
            IDeletableEntityRepository<Address> addressesRepository,
            IRepository<Image> imagesRepository,
            IRepository<LogoImage> logoImagesRepository,
            IDeletableEntityRepository<WorkTime> workTimesRepository,
            IDeletableEntityRepository<Amentity> amentitiesRepository,
            IDeletableEntityRepository<Cuisine> cuisinesRepository,
            IDeletableEntityRepository<Payment> paymentsRepository,
            IDeletableEntityRepository<Music> musicRepository)
        {
            this.placesRepository = placesRepository;
            this.locationsRepository = locationsRepository;
            this.addressesRepository = addressesRepository;
            this.imagesRepository = imagesRepository;
            this.logoImagesRepository = logoImagesRepository;
            this.workTimesRepository = workTimesRepository;
            this.amentitiesRepository = amentitiesRepository;
            this.cuisinesRepository = cuisinesRepository;
            this.paymentsRepository = paymentsRepository;
            this.musicRepository = musicRepository;
        }

        public async Task CreateAsync(CreatePlaceInputModel input, string userId, string imagePath)
        {
            var place = new Place
            {
                CreatedByUserId = userId,
                Name = input.Name,
                Description = input.Description,
                WebUrl = input.WebUrl,
            };
            var currentId = this.placesRepository.AllAsNoTracking();
            await this.placesRepository.AddAsync(place);
            await this.placesRepository.SaveChangesAsync();

            await this.CreatePlaceLocations(input, place);
            await this.CreatePlaceAddress(input, place);
            await this.CreatePlaceWorkingTime(input, place);

            // Logo Image /wwwroot/images/places/jhdsi-343g3h453-=g34g.jpg
            await this.SavePlaceLogoImage(input, userId, imagePath, place);
            await this.SavePlaceImages(input, userId, imagePath, place);

            await this.CreatePlaceAmentities(input, place);
            await this.CreatePlaceCuisineTypes(input, place);
            await this.CreatePlacePaymentTypes(input, place);
            await this.CreatePlaceMusicTypes(input, place);

            await this.placesRepository.SaveChangesAsync();
        }

        private async Task CreatePlaceLocations(CreatePlaceInputModel input, Place place)
        {
            var location = new Location()
            {
                Lattitude = input.Lattitude,
                Longtitude = input.Longtitude,
                GoogleAddress = input.GoogleAddress,
                PlaceId = place.Id,
            };

            await this.locationsRepository.AddAsync(location);
            await this.locationsRepository.SaveChangesAsync();
        }

        private async Task CreatePlaceAddress(CreatePlaceInputModel input, Place place)
        {
            var address = new Address()
            {
                City = input.City,
                Street = input.Street,
                PlaceId = place.Id,
            };

            await this.addressesRepository.AddAsync(address);
            await this.addressesRepository.SaveChangesAsync();
        }

        private async Task CreatePlaceWorkingTime(CreatePlaceInputModel input, Place place)
        {
            var workTime = new WorkTime()
            {
                OpenTime = input.OpenTime,
                CloseTime = input.CloseTime,
                PlaceId = place.Id,
            };

            if (!this.workTimesRepository.AllAsNoTracking().Any(x => x.PlaceId == workTime.PlaceId))
            {
                await this.workTimesRepository.AddAsync(workTime);
            }

            await this.workTimesRepository.SaveChangesAsync();
        }

        private async Task SavePlaceLogoImage(CreatePlaceInputModel input, string userId, string imagePath, Place place)
        {
            Directory.CreateDirectory($"{imagePath}/places/");
            var logoImage = input.LogoImage;
            var extensionLogoImage = Path.GetExtension(logoImage.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extensionLogoImage.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extensionLogoImage}");
            }

            var logoImg = new LogoImage()
            {
                PlaceId = place.Id,
                Extension = extensionLogoImage,
                RemoteImageUrl = logoImage.FileName,
                AddedByUserId = userId,
            };

            await this.logoImagesRepository.AddAsync(logoImg);
            await this.logoImagesRepository.SaveChangesAsync();

            place.LogoImageId = logoImg.Id;
        }

        private async Task SavePlaceImages(CreatePlaceInputModel input, string userId, string imagePath, Place place)
        {
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    PlaceId = place.Id,
                    AddedByUserId = userId,
                    Extension = extension,
                };
                place.Images.Add(dbImage);
                await this.imagesRepository.AddAsync(dbImage);
                await this.imagesRepository.SaveChangesAsync();

                var physicalPath = $"{imagePath}/places/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
        }

        private async Task CreatePlaceAmentities(CreatePlaceInputModel input, Place place)
        {
            var amentityDb = new Amentity();
            foreach (var amentity in input.Amentities)
            {
                amentityDb.Name = amentity.Value;
                amentityDb.PlaceId = place.Id;
                await this.amentitiesRepository.AddAsync(amentityDb);
            }

            await this.amentitiesRepository.SaveChangesAsync();
        }

        private async Task CreatePlaceCuisineTypes(CreatePlaceInputModel input, Place place)
        {
            var cuisineDb = new Cuisine();
            foreach (var cuisine in input.Cuisines)
            {
                cuisineDb.Name = cuisine.Value;
                cuisineDb.PlaceId = place.Id;
                await this.cuisinesRepository.AddAsync(cuisineDb);
            }

            await this.cuisinesRepository.SaveChangesAsync();
        }

        private async Task CreatePlacePaymentTypes(CreatePlaceInputModel input, Place place)
        {
            var paymentDb = new Payment();
            foreach (var payment in input.PaymentTypes)
            {
                paymentDb.Name = payment.Value;
                paymentDb.PlaceId = place.Id;
                if (!this.paymentsRepository.AllAsNoTracking().Any(x => x.PlaceId == paymentDb.PlaceId))
                {
                    await this.paymentsRepository.AddAsync(paymentDb);
                }
            }

            await this.paymentsRepository.SaveChangesAsync();
        }

        private async Task CreatePlaceMusicTypes(CreatePlaceInputModel input, Place place)
        {
            var musicType = new Music();
            foreach (var music in input.MusicTypes)
            {
                musicType.Name = music.Value;
                musicType.PlaceId = place.Id;
                await this.musicRepository.AddAsync(musicType);
            }

            await this.musicRepository.SaveChangesAsync();
        }
    }
}
