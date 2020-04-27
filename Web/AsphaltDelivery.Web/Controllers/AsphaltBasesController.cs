namespace AsphaltDelivery.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.AsphaltBases;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.AsphaltBases;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AsphaltBasesController : BaseController
    {
        private readonly IAsphaltBaseService asphaltBaseService;

        public AsphaltBasesController(IAsphaltBaseService asphaltBaseService)
        {
            this.asphaltBaseService = asphaltBaseService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var asphaltBases = this.asphaltBaseService.All().To<AllAsphaltBasesServiceModel>().To<AsphaltBasesListingViewModel>();

            return this.View(asphaltBases);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var asphaltBase = await this.asphaltBaseService.GetByIdAsync(id);

            if (asphaltBase == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsAsphaltBaseServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsAsphaltBaseServiceModel>(asphaltBase);
            var asphaltBaseDetailsViewModel = AutoMapperConfig.MapperInstance.Map<AsphaltBaseDetailsViewModel>(detailsAsphaltBaseServiceModel);

            if (string.IsNullOrEmpty(asphaltBaseDetailsViewModel.CourseIds))
            {
                asphaltBaseDetailsViewModel.CourseIds = "No courses";
            }

            return this.View(asphaltBaseDetailsViewModel);
        }
    }
}
