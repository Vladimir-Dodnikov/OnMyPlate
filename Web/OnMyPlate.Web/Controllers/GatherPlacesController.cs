namespace OnMyPlate.Web.Controllers
{
    using System.Data;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using OnMyPlate.Common;
    using OnMyPlate.Data;
    using OnMyPlate.Services;

    [Authorize]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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
            //await this.rezzoScraperService.ImportPlacesAsync();

            return this.View();
        }
    }
}
