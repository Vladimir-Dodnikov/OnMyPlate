namespace OnMyPlate.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using OnMyPlate.Services.Data;
    using OnMyPlate.Web.ViewModels.PlacesViewModel;

    public class PlacesController : Controller
    {
        private readonly IAmentitiesService amentityService;
        private readonly ICuisinesService cuisineService;
        private readonly IPaymentsService paymentsService;
        private readonly IMusicService musicService;
        private readonly IPlacesService placesService;
        private readonly IWebHostEnvironment environment;

        public PlacesController(
            IAmentitiesService amentityService,
            ICuisinesService cuisineService,
            IPaymentsService paymentsService,
            IMusicService musicService,
            IPlacesService placesService,
            IWebHostEnvironment environment)
        {
            this.amentityService = amentityService;
            this.cuisineService = cuisineService;
            this.paymentsService = paymentsService;
            this.musicService = musicService;
            this.placesService = placesService;
            this.environment = environment;
            this.paymentsService = paymentsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePlaceInputModel();
            viewModel.Amentities = this.amentityService.GetAllAmentitiesAsKeyValuePairs();
            viewModel.Cuisines = this.cuisineService.GetAllCuisineAsKeyValuePairs();
            viewModel.PaymentTypes = this.paymentsService.GetAllPaymentTypesAsKeyValuePairs();
            viewModel.MusicTypes = this.musicService.GetAllMusicTypesAsKeyValuePairs();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Amentities = this.amentityService.GetAllAmentitiesAsKeyValuePairs();
                input.Cuisines = this.cuisineService.GetAllCuisineAsKeyValuePairs();
                input.PaymentTypes = this.paymentsService.GetAllPaymentTypesAsKeyValuePairs();
                input.MusicTypes = this.musicService.GetAllMusicTypesAsKeyValuePairs();
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                var selectedAmentities = this.Request.Form["Amentities"].ToArray();
                var selectedCuisineTypes = this.Request.Form["Cuisines"].ToArray();
                var selectedPaymentTypes = this.Request.Form["PaymentTypes"].ToArray();
                var selectedMusicTypes = this.Request.Form["MusicTypes"].ToArray();
                await this.placesService.CreateAsync(input, userId, selectedAmentities, selectedCuisineTypes, selectedMusicTypes, selectedPaymentTypes, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Amentities = this.amentityService.GetAllAmentitiesAsKeyValuePairs();
                input.Cuisines = this.cuisineService.GetAllCuisineAsKeyValuePairs();
                input.PaymentTypes = this.paymentsService.GetAllPaymentTypesAsKeyValuePairs();
                input.MusicTypes = this.musicService.GetAllMusicTypesAsKeyValuePairs();
                Console.WriteLine(ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Recipe added successfully.";

            // TODO: Redirect to PlacesPage
            return this.Redirect("/");
        }
    }
}
