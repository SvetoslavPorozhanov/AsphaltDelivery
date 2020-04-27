namespace AsphaltDelivery.Services.Data.AsphaltBases
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;

    public interface IAsphaltBaseService
    {
        Task<bool> ExistsAsync(int id);

        IQueryable<AsphaltBase> All();

        Task CreateAsync(CreateAsphaltBaseServiceModel createAsphaltBaseServiceModel);

        Task<AsphaltBase> GetByIdAsync(int id);

        Task EditAsync(EditAsphaltBaseServiceModel editAsphaltBaseServiceModel);

        Task DeleteByIdAsync(int id);
    }
}
