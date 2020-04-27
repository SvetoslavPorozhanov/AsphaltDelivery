namespace AsphaltDelivery.Services.Data.Drivers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Drivers;

    public interface IDriverService
    {
        Task<bool> ExistsAsync(int id);

        IQueryable<Driver> All();

        Task CreateAsync(CreateDriverServiceModel createDriverServiceModel);

        Task<Driver> GetByIdAsync(int id);

        Task EditAsync(EditDriverServiceModel editDriverServiceModel);

        Task DeleteByIdAsync(int id);
    }
}
