namespace OnMyPlate.Web.Areas.Administration.Controllers
{
    using OnMyPlate.Common;
    using OnMyPlate.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
