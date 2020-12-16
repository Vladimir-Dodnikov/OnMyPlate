namespace OnMyPlate.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnMyPlate.Common;
    using OnMyPlate.Services;

    //[Authorize]
    //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class GatherPlacesController : BaseController
    {
        private readonly IRezzoScraperService rezzoScraperService;

        public GatherPlacesController(IRezzoScraperService rezzoScraperService)
        {
            this.rezzoScraperService = rezzoScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Add()
        {
            await this.rezzoScraperService.ImportPlacesAsync();

            return this.View();
        }
    }
}
