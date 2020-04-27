namespace AsphaltDelivery.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.Firms;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Firms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FirmsController : BaseController
    {
        private readonly IFirmService firmService;

        public FirmsController(IFirmService firmService)
        {
            this.firmService = firmService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var firms = this.firmService.All().To<AllFirmsServiceModel>().To<FirmsListingViewModel>();

            return this.View(firms);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var firm = await this.firmService.GetByIdAsync(id);

            if (firm == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsFirmServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsFirmServiceModel>(firm);
            var firmDetailsViewModel = AutoMapperConfig.MapperInstance.Map<FirmDetailsViewModel>(detailsFirmServiceModel);

            if (string.IsNullOrEmpty(firmDetailsViewModel.DriverFullNames))
            {
                firmDetailsViewModel.DriverFullNames = "No drivers";
            }

            if (string.IsNullOrEmpty(firmDetailsViewModel.TruckRegistrationNumbers))
            {
                firmDetailsViewModel.TruckRegistrationNumbers = "No trucks";
            }

            if (string.IsNullOrEmpty(firmDetailsViewModel.CourseIds))
            {
                firmDetailsViewModel.CourseIds = "No courses";
            }

            return this.View(firmDetailsViewModel);
        }
    }
}
