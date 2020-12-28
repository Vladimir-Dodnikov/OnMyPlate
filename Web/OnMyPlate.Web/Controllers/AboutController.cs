namespace OnMyPlate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Soon()
        {
            return this.View();
        }
    }
}
