namespace OnMyPlate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OnMyPlate.Services.Data;
    using OnMyPlate.Web.ViewModels.Places;
    using OnMyPlate.Web.ViewModels.Search;

    public class SearchController : BaseController
    {
        private readonly ICuisinesService cuisineService;
        private readonly IPlacesService placesService;

        public SearchController(
            ICuisinesService cuisineService,
            IPlacesService placesService)
        {
            this.cuisineService = cuisineService;
            this.placesService = placesService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Cuisines = this.cuisineService.GetAllCuisineAsKeyValuePairs(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Places = this.placesService
                .GetByCusines<PlaceViewModel>(input.Cuisines),
            };

            return this.View(viewModel);
        }
    }
}
