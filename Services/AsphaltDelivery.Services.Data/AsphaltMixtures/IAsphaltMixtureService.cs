namespace AsphaltDelivery.Services.Data.AsphaltMixtures
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;

    public interface IAsphaltMixtureService
    {
        Task<bool> ExistsAsync(int id);

        IQueryable<AsphaltMixture> All();

        Task CreateAsync(CreateAsphaltMixtureServiceModel createAsphaltMixtureServiceModel);

        Task<AsphaltMixture> GetByIdAsync(int id);

        Task EditAsync(EditAsphaltMixtureServiceModel editAsphaltMixtureServiceModel);

        Task DeleteByIdAsync(int id);
    }
}
