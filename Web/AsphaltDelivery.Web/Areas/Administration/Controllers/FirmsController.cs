namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.Firms;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Firms;
    using Microsoft.AspNetCore.Mvc;

    public class FirmsController : AdministrationController
    {
        private readonly IFirmService firmService;

        public FirmsController(IFirmService firmService)
        {
            this.firmService = firmService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FirmCreateInputModel firmCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(firmCreateInputModel);
            }

            var createFirmServiceModel = AutoMapperConfig.MapperInstance.Map<CreateFirmServiceModel>(firmCreateInputModel);

            await this.firmService.CreateAsync(createFirmServiceModel);

            return this.Redirect($"/Firms/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var firm = await this.firmService.GetByIdAsync(id);

            if (firm == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editFirmServiceModel = AutoMapperConfig.MapperInstance.Map<EditFirmServiceModel>(firm);
            var firmEditInputModel = AutoMapperConfig.MapperInstance.Map<FirmEditInputModel>(editFirmServiceModel);

            return this.View(firmEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FirmEditInputModel firmEditInputModel)
        {
            if (await this.firmService.ExistsAsync(firmEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(firmEditInputModel);
            }

            var editFirmServiceModel = AutoMapperConfig.MapperInstance.Map<EditFirmServiceModel>(firmEditInputModel);

            await this.firmService.EditAsync(editFirmServiceModel);

            return this.Redirect($"/Firms/Details/{editFirmServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var firm = await this.firmService.GetByIdAsync(id);
            var deleteFirmServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteFirmServiceModel>(firm);
            var firmDeleteViewModel = AutoMapperConfig.MapperInstance.Map<FirmDeleteViewModel>(deleteFirmServiceModel);

            return this.View(firmDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FirmDeleteViewModel firmDeleteViewModel)
        {
            if (await this.firmService.ExistsAsync(firmDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.firmService.DeleteByIdAsync(firmDeleteViewModel.Id);

            return this.Redirect($"/Firms/All");
        }
    }
}
