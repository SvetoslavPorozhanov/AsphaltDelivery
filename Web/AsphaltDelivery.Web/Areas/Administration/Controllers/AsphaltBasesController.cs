namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.AsphaltBases;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.AsphaltBases;
    using Microsoft.AspNetCore.Mvc;

    public class AsphaltBasesController : AdministrationController
    {
        private readonly IAsphaltBaseService asphaltBaseService;

        public AsphaltBasesController(IAsphaltBaseService asphaltBaseService)
        {
            this.asphaltBaseService = asphaltBaseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AsphaltBaseCreateInputModel asphaltBaseCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(asphaltBaseCreateInputModel);
            }

            var createAsphaltBaseServiceModel = AutoMapperConfig.MapperInstance.Map<CreateAsphaltBaseServiceModel>(asphaltBaseCreateInputModel);

            await this.asphaltBaseService.CreateAsync(createAsphaltBaseServiceModel);

            return this.Redirect($"/AsphaltBases/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var asphaltBase = await this.asphaltBaseService.GetByIdAsync(id);

            if (asphaltBase == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editAsphaltBaseServiceModel = AutoMapperConfig.MapperInstance.Map<EditAsphaltBaseServiceModel>(asphaltBase);
            var asphaltBaseEditInputModel = AutoMapperConfig.MapperInstance.Map<AsphaltBaseEditInputModel>(editAsphaltBaseServiceModel);

            return this.View(asphaltBaseEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AsphaltBaseEditInputModel asphaltBaseEditInputModel)
        {
            if (await this.asphaltBaseService.ExistsAsync(asphaltBaseEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(asphaltBaseEditInputModel);
            }

            var editAsphaltBaseServiceModel = AutoMapperConfig.MapperInstance.Map<EditAsphaltBaseServiceModel>(asphaltBaseEditInputModel);

            await this.asphaltBaseService.EditAsync(editAsphaltBaseServiceModel);

            return this.Redirect($"/AsphaltBases/Details/{editAsphaltBaseServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var asphaltBase = await this.asphaltBaseService.GetByIdAsync(id);
            var deleteAsphaltBaseServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteAsphaltBaseServiceModel>(asphaltBase);
            var asphaltBaseDeleteViewModel = AutoMapperConfig.MapperInstance.Map<AsphaltBaseDeleteViewModel>(deleteAsphaltBaseServiceModel);

            return this.View(asphaltBaseDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AsphaltBaseDeleteViewModel asphaltBaseDeleteViewModel)
        {
            if (await this.asphaltBaseService.ExistsAsync(asphaltBaseDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.asphaltBaseService.DeleteByIdAsync(asphaltBaseDeleteViewModel.Id);

            return this.Redirect($"/AsphaltBases/All");
        }
    }
}
