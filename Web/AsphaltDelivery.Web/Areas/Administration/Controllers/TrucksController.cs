namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Data.Trucks;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Trucks;
    using Microsoft.AspNetCore.Mvc;

    public class TrucksController : AdministrationController
    {
        private readonly ITruckService truckService;

        public TrucksController(ITruckService truckService)
        {
            this.truckService = truckService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TruckCreateInputModel truckCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(truckCreateInputModel);
            }

            var createTruckServiceModel = AutoMapperConfig.MapperInstance.Map<CreateTruckServiceModel>(truckCreateInputModel);

            await this.truckService.CreateAsync(createTruckServiceModel);

            return this.Redirect($"/Trucks/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var truck = await this.truckService.GetByIdAsync(id);

            if (truck == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editTruckServiceModel = AutoMapperConfig.MapperInstance.Map<EditTruckServiceModel>(truck);
            var truckEditInputModel = AutoMapperConfig.MapperInstance.Map<TruckEditInputModel>(editTruckServiceModel);

            return this.View(truckEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TruckEditInputModel truckEditInputModel)
        {
            if (await this.truckService.ExistsAsync(truckEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(truckEditInputModel);
            }

            var editTruckServiceModel = AutoMapperConfig.MapperInstance.Map<EditTruckServiceModel>(truckEditInputModel);

            await this.truckService.EditAsync(editTruckServiceModel);

            return this.Redirect($"/Trucks/Details/{editTruckServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var truck = await this.truckService.GetByIdAsync(id);
            var deleteTruckServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteTruckServiceModel>(truck);
            var truckDeleteViewModel = AutoMapperConfig.MapperInstance.Map<TruckDeleteViewModel>(deleteTruckServiceModel);

            return this.View(truckDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TruckDeleteViewModel truckDeleteViewModel)
        {
            if (await this.truckService.ExistsAsync(truckDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.truckService.DeleteByIdAsync(truckDeleteViewModel.Id);

            return this.Redirect($"/Trucks/All");
        }
    }
}
