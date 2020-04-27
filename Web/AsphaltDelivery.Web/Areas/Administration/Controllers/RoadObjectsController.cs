namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Data.RoadObjects;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.RoadObjects;
    using Microsoft.AspNetCore.Mvc;

    public class RoadObjectsController : AdministrationController
    {
        private readonly IRoadObjectService roadObjectService;

        public RoadObjectsController(IRoadObjectService roadObjectService)
        {
            this.roadObjectService = roadObjectService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadObjectCreateInputModel roadObjectCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(roadObjectCreateInputModel);
            }

            var createRoadObjectServiceModel = AutoMapperConfig.MapperInstance.Map<CreateRoadObjectServiceModel>(roadObjectCreateInputModel);

            await this.roadObjectService.CreateAsync(createRoadObjectServiceModel);

            return this.Redirect($"/RoadObjects/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var roadObject = await this.roadObjectService.GetByIdAsync(id);

            if (roadObject == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editRoadObjectServiceModel = AutoMapperConfig.MapperInstance.Map<EditRoadObjectServiceModel>(roadObject);
            var roadObjectEditInputModel = AutoMapperConfig.MapperInstance.Map<RoadObjectEditInputModel>(editRoadObjectServiceModel);

            return this.View(roadObjectEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoadObjectEditInputModel roadObjectEditInputModel)
        {
            if (await this.roadObjectService.ExistsAsync(roadObjectEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(roadObjectEditInputModel);
            }

            var editRoadObjectServiceModel = AutoMapperConfig.MapperInstance.Map<EditRoadObjectServiceModel>(roadObjectEditInputModel);

            await this.roadObjectService.EditAsync(editRoadObjectServiceModel);

            return this.Redirect($"/RoadObjects/Details/{editRoadObjectServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var roadObject = await this.roadObjectService.GetByIdAsync(id);
            var deleteRoadObjectServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteRoadObjectServiceModel>(roadObject);
            var roadObjectDeleteViewModel = AutoMapperConfig.MapperInstance.Map<RoadObjectDeleteViewModel>(deleteRoadObjectServiceModel);

            return this.View(roadObjectDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoadObjectDeleteViewModel roadObjectDeleteViewModel)
        {
            if (await this.roadObjectService.ExistsAsync(roadObjectDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.roadObjectService.DeleteByIdAsync(roadObjectDeleteViewModel.Id);

            return this.Redirect($"/RoadObjects/All");
        }
    }
}
