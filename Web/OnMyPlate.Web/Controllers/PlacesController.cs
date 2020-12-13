namespace OnMyPlate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnMyPlate.Services.Data;
    using OnMyPlate.Web.ViewModels.PlacesViewModel;

    public class PlacesController : Controller
    {
        private readonly IAmentityService amentityService;
        private readonly ICuisineService cuisineService;
        private readonly IPaymentService paymentsService;
        private readonly IMusicService musicService;

        public PlacesController(
            IAmentityService amentityService,
            ICuisineService cuisineService,
            IPaymentService paymentsService,
            IMusicService musicService)
        {
            this.amentityService = amentityService;
            this.cuisineService = cuisineService;
            this.paymentsService = paymentsService;
            this.musicService = musicService;
            this.paymentsService = paymentsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePlaceInputModel();
            viewModel.Amentities = this.amentityService.GetAllAmentitiesAsKeyValuePairs();
            viewModel.Cuisines = this.cuisineService.GetAllCuisineAsKeyValuePairs();
            viewModel.PaymentTypes = this.paymentsService.GetAllPaymentTypesAsKeyValuePairs();
            viewModel.MusicTypes = this.musicService.GetAllMusicTypesAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePlaceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Amentities = this.amentityService.GetAllAmentitiesAsKeyValuePairs();
                input.Cuisines = this.cuisineService.GetAllCuisineAsKeyValuePairs();
                input.PaymentTypes = this.paymentsService.GetAllPaymentTypesAsKeyValuePairs();
                input.MusicTypes = this.musicService.GetAllMusicTypesAsKeyValuePairs();
                return this.View(input);
            }

            // TODO: Redirect to PlacePage
            return this.Redirect("/");
        }
    }
}
