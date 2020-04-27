namespace AsphaltDelivery.Services.Data.Firms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Firms;

    public interface IFirmService
    {
        Task<bool> ExistsAsync(int id);

        IQueryable<Firm> All();

        Task CreateAsync(CreateFirmServiceModel createFirmServiceModel);

        Task<Firm> GetByIdAsync(int id);

        Task EditAsync(EditFirmServiceModel editFirmServiceModel);

        Task DeleteByIdAsync(int id);
    }
}
