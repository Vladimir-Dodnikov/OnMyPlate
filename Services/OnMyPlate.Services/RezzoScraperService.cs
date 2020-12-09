﻿namespace OnMyPlate.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.EntityFrameworkCore;
    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Models;

    public class RezzoScraperService : IRezzoScraperService
    {
        private const string BaseUrl = "https://rezzo.bg/en/r/v/{0}";
        private const string Path = "ImportRezzoIds.txt";

        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<Place> placesRepository;
        private readonly IDeletableEntityRepository<Location> locationsRepository;
        private readonly IDeletableEntityRepository<Address> addressesRepository;
        private readonly IDeletableEntityRepository<WorkTime> workTimesRepository;
        private readonly IDeletableEntityRepository<Amentity> amentitiesRepository;
        private readonly IDeletableEntityRepository<Cuisine> cuisinesRepository;
        private readonly IDeletableEntityRepository<Payment> paymentsRepository;
        private readonly IDeletableEntityRepository<Music> musicRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IRepository<Image> imagesRepository;

        public RezzoScraperService(
            IDeletableEntityRepository<Place> placesRepository,
            IDeletableEntityRepository<Location> locationsRepository,
            IDeletableEntityRepository<Address> addressesRepository,
            IRepository<Image> imagesRepository,
            IDeletableEntityRepository<WorkTime> workTimesRepository,
            IDeletableEntityRepository<Amentity> amentitiesRepository,
            IDeletableEntityRepository<Cuisine> cuisinesRepository,
            IDeletableEntityRepository<Payment> paymentsRepository,
            IDeletableEntityRepository<Music> musicRepository,
            IDeletableEntityRepository<Post> postsRepository)
        {
            this.placesRepository = placesRepository;
            this.locationsRepository = locationsRepository;
            this.addressesRepository = addressesRepository;
            this.imagesRepository = imagesRepository;
            this.workTimesRepository = workTimesRepository;
            this.amentitiesRepository = amentitiesRepository;
            this.cuisinesRepository = cuisinesRepository;
            this.paymentsRepository = paymentsRepository;
            this.musicRepository = musicRepository;
            this.postsRepository = postsRepository;

            var config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(config);
        }

        public async Task ImportPlacesAsync()
        {
            var concurrentBag = this.ScrapedPlaces();
            Console.WriteLine($"Scraped places: {concurrentBag.Count}");

            int addedCount = 0;
            foreach (var place in concurrentBag)
            {
                var newPlace = new Place()
                {
                    Name = place.PlaceName,
                    Description = place.PlaceDescription,
                    LogoImage = place.LogoImage,
                    WebUrl = place.WebUrl,
                };
                await this.placesRepository.AddAsync(newPlace);
                await this.placesRepository.SaveChangesAsync();

                var location = new Location();
                location.Lattitude = place.Location.Lattitude;
                location.Longtitude = place.Location.Longtitude;
                location.GoogleAddress = place.Location.GoogleAddress;
                location.PlaceId = newPlace.Id;
                await this.locationsRepository.AddAsync(location);
                await this.locationsRepository.SaveChangesAsync();

                var address = new Address();
                address.City = place.Address.City;
                address.Street = place.Address.Street;
                address.Neighbourhood = place.Address.Neighbourhood;
                address.PlaceId = newPlace.Id;
                await this.addressesRepository.AddAsync(address);
                await this.addressesRepository.SaveChangesAsync();

                var images = place.Images;
                foreach (var img in images)
                {
                    img.PlaceId = newPlace.Id;
                    await this.imagesRepository.AddAsync(img);
                }

                await this.imagesRepository.SaveChangesAsync();

                var workTime = new WorkTime();
                workTime.OpenTime = place.WorkTime.OpenTime;
                workTime.CloseTime = place.WorkTime.CloseTime;
                workTime.PlaceId = newPlace.Id;
                await this.workTimesRepository.AddAsync(workTime);
                await this.workTimesRepository.SaveChangesAsync();

                var amentities = place.Amentities;
                foreach (var amentity in amentities)
                {
                    amentity.PlaceId = newPlace.Id;
                    await this.amentitiesRepository.AddAsync(amentity);
                }

                await this.amentitiesRepository.SaveChangesAsync();

                var cuisines = place.Cuisines;
                foreach (var cuisine in cuisines)
                {
                    cuisine.PlaceId = newPlace.Id;
                    await this.cuisinesRepository.AddAsync(cuisine);
                }

                await this.cuisinesRepository.SaveChangesAsync();

                var payments = place.PaymentTypes;
                foreach (var payment in payments)
                {
                    payment.PlaceId = newPlace.Id;
                    await this.paymentsRepository.AddAsync(payment);
                }

                await this.paymentsRepository.SaveChangesAsync();

                var musicTypes = place.MusicTypes;
                foreach (var music in musicTypes)
                {
                    music.PlaceId = newPlace.Id;
                    await this.musicRepository.AddAsync(music);
                }

                await this.musicRepository.SaveChangesAsync();

                var posts = place.Posts;
                foreach (var post in posts)
                {
                    post.PlaceId = newPlace.Id;
                    await this.postsRepository.AddAsync(post);
                }

                await this.cuisinesRepository.SaveChangesAsync();

                if (++addedCount % 10 == 0)
                {
                    await this.placesRepository.SaveChangesAsync();
                    Console.WriteLine($"Saved count: {addedCount}");
                }
            }

            await this.placesRepository.SaveChangesAsync();
            Console.WriteLine($"Count: {addedCount}");
        }

        private async Task<int> GetOrCreatePlaceAsync(string placeName)
        {
            var place = this.placesRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == placeName);

            if (place != null)
            {
                return place.Id;
            }

            place = new Place
            {
                Name = placeName,
            };

            await this.placesRepository.AddAsync(place);
            await this.placesRepository.SaveChangesAsync();

            return place.Id;
        }

        private ConcurrentBag<PlaceDto> ScrapedPlaces()
        {
            var concurrentBag = new ConcurrentBag<PlaceDto>();

            var resultList = new List<int>();
            File.ReadAllLines(Path)
                .ToList()
                .ForEach((line) =>
                {
                    var numbers = line.Split()
                          .Select(c => Convert.ToInt32(c));
                    resultList.AddRange(numbers);
                });

            Parallel.ForEach(resultList, i =>
            {
                try
                {
                    var place = this.GetPlace(i);
                    concurrentBag.Add(place);
                }
                catch
                {
                    // ignored
                }
            });

            return concurrentBag;
        }

        private PlaceDto GetPlace(int id)
        {
            var url = string.Format(BaseUrl, id);

            var document = this.context
                .OpenAsync(url)
                .GetAwaiter()
                .GetResult();

            if (document.StatusCode == HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException();
            }

            var place = new PlaceDto();

            // Get PlaceName
            place.PlaceName = document.QuerySelector(".upper_right_part > h1").TextContent;

            // Get PlaceAddress
            var placeAddress = document.QuerySelector(".upper_right_part > span").TextContent.Split(", ");

            // if (placeAddress == null)
            // {
            //    throw new InvalidOperationException();
            // }

            place.Address.Street = placeAddress[0];
            place.Address.City = placeAddress[1];

            // Get CuisinesPlace
            // if (document.QuerySelector(".middle > .food_type") == null)
            // {
            //     throw new InvalidOperationException();
            // }

            var cuisinesPlace = document.QuerySelector(".middle > .food_type").TextContent
                .Remove(0, 9)
                .Replace(" and ", ", ")
                .Split(", ");

            foreach (var cuisineType in cuisinesPlace)
            {
                var cuisine = new Cuisine();
                cuisine.Name = cuisineType;

                place.Cuisines.Add(cuisine);
            }

            // Get MusicType
            var musicTag = document.QuerySelector(".middle > .music_type");
            if (musicTag != null)
            {
                var musicTypesPlace = document.QuerySelector(".middle > .music_type").TextContent
                .Remove(0, 7)
                .Replace(" and ", ", ")?
                .Split(", ");

                foreach (var musicType in musicTypesPlace)
                {
                    var music = new Music();
                    music.Name = musicType;

                    place.MusicTypes.Add(music);
                }
            }

            // Get Locations
            var googleAddress = document.QuerySelector(".restaurant__location__map > iframe").GetAttribute("src");
            place.Location = new Location();
            place.Location.GoogleAddress = googleAddress;

            var location = googleAddress.Split("&q=")[1].Split(",");
            place.Location.Lattitude = location[0];
            place.Location.Longtitude = location[1];

            // Get PlaceDescription
            place.PlaceDescription = document.QuerySelector(".upper > p").TextContent;

            // Get Amentities
            var additionalInfo = document.QuerySelectorAll(".additional_info > table > tbody > tr > td");

            var amentitiesOne = additionalInfo[1].TextContent.Replace(" and ", ", ").Split(", ");
            var amentitiesTwo = additionalInfo[5].TextContent.Split(", ");
            var amentities = amentitiesOne.Concat(amentitiesTwo).ToArray();

            foreach (var item in amentities)
            {
                var amentity = new Amentity();
                amentity.Name = item;

                place.Amentities.Add(amentity);
            }

            // Get Paymentypes
            var paymentTypes = additionalInfo[3].TextContent.Replace(" and ", ", ").Split(", ");
            foreach (var item in paymentTypes)
            {
                var payment = new Payment();
                payment.Name = item;

                place.PaymentTypes.Add(payment);
            }

            // Get WorkTime
            var workTimes = additionalInfo[7].TextContent.Trim().Split(" - ");

            var workTime = new WorkTime();
            workTime.OpenTime = TimeSpan.Parse(workTimes[0].TrimEnd());
            workTime.CloseTime = TimeSpan.Parse(workTimes[1].TrimEnd() == "24:00" ? "00:00" : workTimes[1].TrimEnd());

            place.WorkTime = workTime;

            // Get Facebook
            place.WebUrl = document.QuerySelector(".red_link_button").GetAttribute("href");

            // Get Comments
            var comments = document.QuerySelectorAll(".comments_restaurant_view");
            foreach (var section in comments)
            {
                var userComment = section.QuerySelectorAll(".comment");
                foreach (var tag in userComment)
                {
                    var post = new Post();
                    post.Author = new ApplicationUser();
                    var name = tag.QuerySelector(".author > div").TextContent.Trim().Split(" ");
                    post.Author.FirstName = name[0];
                    post.Author.LastName = name[1];

                    var data = tag.QuerySelector(".author > span").TextContent.Trim().Split(" / ");
                    var cityPost = data[0];
                    post.Author.City = cityPost;

                    var dayAndMonth = DateTime.ParseExact($"{data[1]}, 2019", "dd MMMM, yyyy", CultureInfo.InvariantCulture);
                    var hoursAndMinutes = data[2].Split(" ")[0];
                    post.Date = new DateTime();
                    post.Date = dayAndMonth.Add(TimeSpan.Parse(hoursAndMinutes, CultureInfo.InvariantCulture));

                    var text = tag.QuerySelector(".comment_right").TextContent.Trim();
                    post.PostDescription = text;

                    place.Posts.Add(post);
                }
            }

            // Get PlaceImages
            var imagesWrapper = document.QuerySelectorAll(".upper_restaurant_view");
            foreach (var item in imagesWrapper)
            {
                var imageTag = item.QuerySelectorAll(".big_image > img");
                foreach (var img in imageTag)
                {
                    // /files/images/3845/fit_120_80.jpg
                    var imageUrl = string.Concat("https://rezzo.bg", img.GetAttribute("src"));

                    var image = new Image();
                    image.RemoteImageUrl = imageUrl;
                    place.Images.Add(image);
                }
            }

            // Get PlaceLogo
            var placeLogoSrc = document.QuerySelector(".restaurant_logo").GetAttribute("src");
            place.LogoImage = string.Concat("https://rezzo.bg", placeLogoSrc);

            return place;
        }
    }
}