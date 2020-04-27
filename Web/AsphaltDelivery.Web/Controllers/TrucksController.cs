namespace AsphaltDelivery.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Data.Trucks;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Trucks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TrucksController : BaseController
    {
        private readonly ITruckService truckService;

        public TrucksController(ITruckService truckService)
        {
            this.truckService = truckService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var trucks = this.truckService.All().To<AllTrucksServiceModel>().To<TrucksListingViewModel>();

            return this.View(trucks);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var truck = await this.truckService.GetByIdAsync(id);

            if (truck == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsTruckServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsTruckServiceModel>(truck);
            var truckDetailsViewModel = AutoMapperConfig.MapperInstance.Map<TruckDetailsViewModel>(detailsTruckServiceModel);

            if (string.IsNullOrEmpty(truckDetailsViewModel.DriverFullNames))
            {
                truckDetailsViewModel.DriverFullNames = "No drivers";
            }

            if (string.IsNullOrEmpty(truckDetailsViewModel.FirmName))
            {
                truckDetailsViewModel.FirmName = "No firm";
            }

            if (string.IsNullOrEmpty(truckDetailsViewModel.CourseIds))
            {
                truckDetailsViewModel.CourseIds = "No courses";
            }

            return this.View(truckDetailsViewModel);
        }
    }
}
