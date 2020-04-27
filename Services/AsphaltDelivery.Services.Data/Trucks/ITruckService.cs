namespace AsphaltDelivery.Services.Data.Trucks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Trucks;

    public interface ITruckService
    {
        Task<bool> ExistsAsync(int id);

        IQueryable<Truck> All();

        Task CreateAsync(CreateTruckServiceModel createTruckServiceModel);

        Task<Truck> GetByIdAsync(int id);

        Task EditAsync(EditTruckServiceModel editTruckServiceModel);

        Task DeleteByIdAsync(int id);
    }
}
