namespace AsphaltDelivery.Services.Data.RoadObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.RoadObjects;

    public interface IRoadObjectService
    {
        Task<bool> ExistsAsync(int id);

        IQueryable<RoadObject> All();

        Task CreateAsync(CreateRoadObjectServiceModel createRoadObjectServiceModel);

        Task<RoadObject> GetByIdAsync(int id);

        Task EditAsync(EditRoadObjectServiceModel editRoadObjectServiceModel);

        Task DeleteByIdAsync(int id);
    }
}
