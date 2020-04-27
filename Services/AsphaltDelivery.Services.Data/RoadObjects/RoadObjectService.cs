namespace AsphaltDelivery.Services.Data.RoadObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class RoadObjectService : IRoadObjectService
    {
        private const string EmptyRoadObjectErrorMessage = "One or more required properties are null.";
        private const string RoadObjectExistErrorMessage = "Road object's name already exists.";
        private const string RoadObjectNameMaxLengthErrorMessage = "Road object's name cannot be more than {0} characters.";
        private const string InvalidRoadObjectIdErrorMessage = "Road object with ID: {0} does not exist.";
        private readonly ApplicationDbContext context;

        public RoadObjectService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<RoadObject> All()
        {
            return this.context.RoadObjects;
        }

        public async Task CreateAsync(CreateRoadObjectServiceModel createRoadObjectServiceModel)
        {
            var roadObject = AutoMapperConfig.MapperInstance.Map<RoadObject>(createRoadObjectServiceModel);

            if (string.IsNullOrWhiteSpace(roadObject.Name))
            {
                throw new ArgumentNullException(EmptyRoadObjectErrorMessage);
            }

            if (await this.context.RoadObjects.AnyAsync(ro => ro.Name == roadObject.Name))
            {
                throw new InvalidOperationException(RoadObjectExistErrorMessage);
            }

            if (roadObject.Name.Length > AttributesConstraints.RoadObjectNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(RoadObjectNameMaxLengthErrorMessage, AttributesConstraints.RoadObjectNameMaxLength));
            }

            await this.context.RoadObjects.AddAsync(roadObject);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var roadObject = await this.context
                .RoadObjects
                .FindAsync(id);

            if (roadObject == null)
            {
                throw new ArgumentNullException(string.Format(InvalidRoadObjectIdErrorMessage, id));
            }

            this.context.RoadObjects.Remove(roadObject); // Cascade restrict error?
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditRoadObjectServiceModel editRoadObjectServiceModel)
        {
            var roadObject = await this.context
                .RoadObjects
                .FindAsync(editRoadObjectServiceModel.Id);

            if (roadObject == null)
            {
                throw new ArgumentNullException(string.Format(InvalidRoadObjectIdErrorMessage, editRoadObjectServiceModel.Id));
            }

            if (string.IsNullOrWhiteSpace(editRoadObjectServiceModel.Name))
            {
                throw new ArgumentNullException(EmptyRoadObjectErrorMessage);
            }

            if (await this.context.RoadObjects.AnyAsync(ro => ro.Name == editRoadObjectServiceModel.Name))
            {
                throw new InvalidOperationException(RoadObjectExistErrorMessage);
            }

            if (editRoadObjectServiceModel.Name.Length > AttributesConstraints.RoadObjectNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(RoadObjectNameMaxLengthErrorMessage, AttributesConstraints.RoadObjectNameMaxLength));
            }

            roadObject.Name = editRoadObjectServiceModel.Name;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.RoadObjects.AnyAsync(ro => ro.Id == id);
        }

        public async Task<RoadObject> GetByIdAsync(int id)
        {
            await this.context.RoadObjects.Include(ab => ab.Courses).ToListAsync();

            var roadObject = await this.context
                .RoadObjects
                .FindAsync(id);

            if (roadObject == null)
            {
                throw new ArgumentNullException(string.Format(InvalidRoadObjectIdErrorMessage, id));
            }

            return roadObject;
        }
    }
}
