namespace OnMyPlate.Web.Controllers.Comments
{
    using Microsoft.AspNetCore.Mvc;

    public class PostController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
