namespace AsphaltDelivery.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.AsphaltMixtures;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AsphaltMixturesController : BaseController
    {
        private readonly IAsphaltMixtureService asphaltMixtureService;

        public AsphaltMixturesController(IAsphaltMixtureService asphaltMixtureService)
        {
            this.asphaltMixtureService = asphaltMixtureService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var asphaltMixtures = this.asphaltMixtureService.All().To<AllAsphaltMixturesServiceModel>().To<AsphaltMixturesListingViewModel>();

            return this.View(asphaltMixtures);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var asphaltMixture = await this.asphaltMixtureService.GetByIdAsync(id);

            if (asphaltMixture == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsAsphaltMixtureServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsAsphaltMixtureServiceModel>(asphaltMixture);
            var asphaltMixtureDetailsViewModel = AutoMapperConfig.MapperInstance.Map<AsphaltMixtureDetailsViewModel>(detailsAsphaltMixtureServiceModel);

            if (string.IsNullOrEmpty(asphaltMixtureDetailsViewModel.CourseIds))
            {
                asphaltMixtureDetailsViewModel.CourseIds = "No courses";
            }

            return this.View(asphaltMixtureDetailsViewModel);
        }
    }
}
