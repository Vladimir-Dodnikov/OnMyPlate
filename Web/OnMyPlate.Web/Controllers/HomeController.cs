namespace OnMyPlate.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using OnMyPlate.Services.Data;
    using OnMyPlate.Web.ViewModels;
    using OnMyPlate.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IPlacesService placesService;
        private readonly IAmentitiesService amentitiesService;
        private readonly ICuisinesService cuisinesService;
        private readonly IMusicService musicService;
        private readonly IPaymentsService paymentsService;
        private readonly IVotesService votesService;

        public HomeController(
            IPlacesService placesService,
            IAmentitiesService amentitiesService,
            ICuisinesService cuisinesService,
            IMusicService musicService,
            IPaymentsService paymentsService,
            IVotesService votesService)
        {
            this.placesService = placesService;
            this.amentitiesService = amentitiesService;
            this.cuisinesService = cuisinesService;
            this.musicService = musicService;
            this.paymentsService = paymentsService;
            this.votesService = votesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                PlacesCount = this.placesService.GetCount(),
                AmentitiesCount = this.amentitiesService.GetCounts(),
                CuisinesCount = this.cuisinesService.GetCounts(),
                PaymentTypesCount = this.paymentsService.GetCounts(),
                MusicTypesCount = this.musicService.GetCounts(),
                RandomPlaces = this.placesService.GetRandom<IndexPagePlaceViewModel>(10),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
