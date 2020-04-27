namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.AsphaltMixtures;
    using Microsoft.AspNetCore.Mvc;

    public class AsphaltMixturesController : AdministrationController
    {
        private readonly IAsphaltMixtureService asphaltMixtureService;

        public AsphaltMixturesController(IAsphaltMixtureService asphaltMixtureService)
        {
            this.asphaltMixtureService = asphaltMixtureService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AsphaltMixtureCreateInputModel asphaltMixtureCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(asphaltMixtureCreateInputModel);
            }

            var createAsphaltMixtureServiceModel = AutoMapperConfig.MapperInstance.Map<CreateAsphaltMixtureServiceModel>(asphaltMixtureCreateInputModel);

            await this.asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModel);

            return this.Redirect($"/AsphaltMixtures/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var asphaltMixture = await this.asphaltMixtureService.GetByIdAsync(id);

            if (asphaltMixture == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editAsphaltMixtureServiceModel = AutoMapperConfig.MapperInstance.Map<EditAsphaltMixtureServiceModel>(asphaltMixture);
            var asphaltMixtureEditInputModel = AutoMapperConfig.MapperInstance.Map<AsphaltMixtureEditInputModel>(editAsphaltMixtureServiceModel);

            return this.View(asphaltMixtureEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AsphaltMixtureEditInputModel asphaltMixtureEditInputModel)
        {
            if (await this.asphaltMixtureService.ExistsAsync(asphaltMixtureEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(asphaltMixtureEditInputModel);
            }

            var editAsphaltMixtureServiceModel = AutoMapperConfig.MapperInstance.Map<EditAsphaltMixtureServiceModel>(asphaltMixtureEditInputModel);

            await this.asphaltMixtureService.EditAsync(editAsphaltMixtureServiceModel);

            return this.Redirect($"/AsphaltMixtures/Details/{editAsphaltMixtureServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var asphaltMixture = await this.asphaltMixtureService.GetByIdAsync(id);
            var deleteAsphaltMixtureServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteAsphaltMixtureServiceModel>(asphaltMixture);
            var asphaltMixtureDeleteViewModel = AutoMapperConfig.MapperInstance.Map<AsphaltMixtureDeleteViewModel>(deleteAsphaltMixtureServiceModel);

            return this.View(asphaltMixtureDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AsphaltMixtureDeleteViewModel asphaltMixtureDeleteViewModel)
        {
            if (await this.asphaltMixtureService.ExistsAsync(asphaltMixtureDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.asphaltMixtureService.DeleteByIdAsync(asphaltMixtureDeleteViewModel.Id);

            return this.Redirect($"/AsphaltMixtures/All");
        }
    }
}
