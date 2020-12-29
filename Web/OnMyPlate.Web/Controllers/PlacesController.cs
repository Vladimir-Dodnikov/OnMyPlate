namespace OnMyPlate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;

    using Microsoft.AspNetCore.Mvc;
    using OnMyPlate.Common;
    using OnMyPlate.Services.Data;
    using OnMyPlate.Services.Messaging;
    using OnMyPlate.Web.ViewModels.Places;

    public class PlacesController : Controller
    {
        private readonly IAmentitiesService amentityService;
        private readonly ICuisinesService cuisineService;
        private readonly IPaymentsService paymentsService;
        private readonly IMusicService musicService;
        private readonly IPlacesService placesService;
        private readonly IWebHostEnvironment environment;
        private readonly IEmailSender emailSender;

        public PlacesController(
            IAmentitiesService amentityService,
            ICuisinesService cuisineService,
            IPaymentsService paymentsService,
            IMusicService musicService,
            IPlacesService placesService,
            IWebHostEnvironment environment,
            IEmailSender emailSender)
        {
            this.amentityService = amentityService;
            this.cuisineService = cuisineService;
            this.paymentsService = paymentsService;
            this.musicService = musicService;
            this.placesService = placesService;
            this.environment = environment;
            this.emailSender = emailSender;
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

            this.TempData["Message"] = "Place added successfully.";

            // TODO: Redirect to PlacesPage
            return this.Redirect("/");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.placesService.GetById<PlaceViewModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, PlaceViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.placesService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.placesService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Newest(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new PlacesInListViewModel()
            {
                ItemsPerPage = GlobalConstants.ItemsPerPage,
                PageNumber = id,
                PlacesCount = this.placesService.GetCount(),
                Places = this.placesService.GetAll<PlaceViewModel>(id, GlobalConstants.ItemsPerPage)
                .OrderByDescending(x => x.CreatedByUserId)
                .Where(x => x.LogoImages.FirstOrDefault() != null),
            };
            return this.View("All", viewModel);
        }

        public IActionResult Popular(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new PlacesInListViewModel()
            {
                ItemsPerPage = GlobalConstants.ItemsPerPage,
                PageNumber = id,
                PlacesCount = this.placesService.GetCount(),
                Places = this.placesService.GetAll<PlaceViewModel>(id, GlobalConstants.ItemsPerPage)
                .OrderByDescending(x => x.Likes),
            };

            return this.View("All", viewModel);
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new PlacesInListViewModel
            {
                ItemsPerPage = GlobalConstants.ItemsPerPage,
                PageNumber = id,
                PlacesCount = this.placesService.GetCount(),
                Places = this.placesService.GetAll<PlaceViewModel>(id, GlobalConstants.ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var place = this.placesService.GetById<PlaceViewModel>(id);
            return this.View(place);
        }

        [HttpPost]
        public async Task<IActionResult> SendToEmail(int id)
        {
            var place = this.placesService.GetById<PlaceViewModel>(id);
            var html = new StringBuilder();
            html.AppendLine($"<h1>{place.Name}</h1>");
            html.AppendLine($"<h3>{place.Description}</h3>");
            html.AppendLine($"<img src=\"{place.Images.FirstOrDefault().RemoteImageUrl}\" />");
            await this.emailSender.SendEmailAsync("onmyplate@onmyplate.com", "OnMyPlate", "povime4686@aranelab.com", place.Name, html.ToString());
            return this.RedirectToAction(nameof(this.ById), new { id });
        }
    }
}
