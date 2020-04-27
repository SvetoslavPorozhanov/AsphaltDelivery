namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Drivers;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Drivers;
    using Microsoft.AspNetCore.Mvc;

    public class DriversController : AdministrationController
    {
        private readonly IDriverService driverService;

        public DriversController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DriverCreateInputModel driverCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(driverCreateInputModel);
            }

            var createDriverServiceModel = AutoMapperConfig.MapperInstance.Map<CreateDriverServiceModel>(driverCreateInputModel);

            await this.driverService.CreateAsync(createDriverServiceModel);

            return this.Redirect($"/Drivers/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var driver = await this.driverService.GetByIdAsync(id);

            if (driver == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editDriverServiceModel = AutoMapperConfig.MapperInstance.Map<EditDriverServiceModel>(driver);
            var driverEditInputModel = AutoMapperConfig.MapperInstance.Map<DriverEditInputModel>(editDriverServiceModel);

            return this.View(driverEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DriverEditInputModel driverEditInputModel)
        {
            if (await this.driverService.ExistsAsync(driverEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(driverEditInputModel);
            }

            var editDriverServiceModel = AutoMapperConfig.MapperInstance.Map<EditDriverServiceModel>(driverEditInputModel);

            await this.driverService.EditAsync(editDriverServiceModel);

            return this.Redirect($"/Drivers/Details/{editDriverServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var driver = await this.driverService.GetByIdAsync(id);
            var deleteDriverServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteDriverServiceModel>(driver);
            var driverDeleteViewModel = AutoMapperConfig.MapperInstance.Map<DriverDeleteViewModel>(deleteDriverServiceModel);

            return this.View(driverDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DriverDeleteViewModel driverDeleteViewModel)
        {
            if (await this.driverService.ExistsAsync(driverDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.driverService.DeleteByIdAsync(driverDeleteViewModel.Id);

            return this.Redirect($"/Drivers/All");
        }
    }
}
