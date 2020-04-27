namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using AsphaltDelivery.Common;
    using AsphaltDelivery.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
