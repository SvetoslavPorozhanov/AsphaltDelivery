namespace AsphaltDelivery.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Data.RoadObjects;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.RoadObjects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class RoadObjectsController : BaseController
    {
        private readonly IRoadObjectService roadObjectService;

        public RoadObjectsController(IRoadObjectService roadObjectService)
        {
            this.roadObjectService = roadObjectService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var roadObjects = this.roadObjectService.All().To<AllRoadObjectsServiceModel>().To<RoadObjectsListingViewModel>();

            return this.View(roadObjects);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var roadObject = await this.roadObjectService.GetByIdAsync(id);

            if (roadObject == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsRoadObjectServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsRoadObjectServiceModel>(roadObject);
            var roadObjectDetailsViewModel = AutoMapperConfig.MapperInstance.Map<RoadObjectDetailsViewModel>(detailsRoadObjectServiceModel);

            if (string.IsNullOrEmpty(roadObjectDetailsViewModel.CourseIds))
            {
                roadObjectDetailsViewModel.CourseIds = "No courses";
            }

            return this.View(roadObjectDetailsViewModel);
        }
    }
}
