namespace AsphaltDelivery.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    
    using AsphaltDelivery.Services.Data.Drivers;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Drivers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DriversController : BaseController
    {
        private readonly IDriverService driverService;

        public DriversController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var drivers = this.driverService.All().To<AllDriversServiceModel>().To<DriversListingViewModel>();

            return this.View(drivers);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var driver = await this.driverService.GetByIdAsync(id);

            if (driver == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsDriverServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsDriverServiceModel>(driver);
            var driverDetailsViewModel = AutoMapperConfig.MapperInstance.Map<DriverDetailsViewModel>(detailsDriverServiceModel);

            if (string.IsNullOrEmpty(driverDetailsViewModel.TruckRegistrationNumbers))
            {
                driverDetailsViewModel.TruckRegistrationNumbers = "No trucks";
            }

            if (string.IsNullOrEmpty(driverDetailsViewModel.FirmName))
            {
                driverDetailsViewModel.FirmName = "No firm";
            }

            if (string.IsNullOrEmpty(driverDetailsViewModel.CourseIds))
            {
                driverDetailsViewModel.CourseIds = "No courses";
            }

            return this.View(driverDetailsViewModel);
        }
    }
}
