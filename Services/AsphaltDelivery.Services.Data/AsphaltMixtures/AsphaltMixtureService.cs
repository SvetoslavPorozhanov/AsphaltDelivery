namespace AsphaltDelivery.Services.Data.AsphaltMixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class AsphaltMixtureService : IAsphaltMixtureService
    {
        private const string EmptyAsphaltMixtureErrorMessage = "One or more required properties are null.";
        private const string AsphaltMixtureExistErrorMessage = "Asphalt mixture's type already exists.";
        private const string AsphaltMixtureTypeMaxLengthErrorMessage = "Asphalt mixture's type cannot be more than {0} characters.";
        private const string InvalidAsphaltMixtureIdErrorMessage = "Asphalt mixture with ID: {0} does not exist.";
        private readonly ApplicationDbContext context;

        public AsphaltMixtureService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<AsphaltMixture> All()
        {
            return this.context.AsphaltMixtures;
        }

        public async Task CreateAsync(CreateAsphaltMixtureServiceModel createAsphaltMixtureServiceModel)
        {
            var asphaltMixture = AutoMapperConfig.MapperInstance.Map<AsphaltMixture>(createAsphaltMixtureServiceModel);

            if (string.IsNullOrWhiteSpace(asphaltMixture.Type))
            {
                throw new ArgumentNullException(EmptyAsphaltMixtureErrorMessage);
            }

            if (await this.context.AsphaltMixtures.AnyAsync(am => am.Type == asphaltMixture.Type))
            {
                throw new InvalidOperationException(AsphaltMixtureExistErrorMessage);
            }

            if (asphaltMixture.Type.Length > AttributesConstraints.AsphaltMixtureTypeMaxLength)
            {
                throw new InvalidOperationException(string.Format(AsphaltMixtureTypeMaxLengthErrorMessage, AttributesConstraints.AsphaltMixtureTypeMaxLength));
            }

            await this.context.AsphaltMixtures.AddAsync(asphaltMixture);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var asphaltMixture = await this.context
                .AsphaltMixtures
                .FindAsync(id);

            if (asphaltMixture == null)
            {
                throw new ArgumentNullException(string.Format(InvalidAsphaltMixtureIdErrorMessage, id));
            }

            this.context.AsphaltMixtures.Remove(asphaltMixture); // Cascade restrict error?
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditAsphaltMixtureServiceModel editAsphaltMixtureServiceModel)
        {
            var asphaltMixture = await this.context
                .AsphaltMixtures
                .FindAsync(editAsphaltMixtureServiceModel.Id);

            if (asphaltMixture == null)
            {
                throw new ArgumentNullException(string.Format(InvalidAsphaltMixtureIdErrorMessage, editAsphaltMixtureServiceModel.Id));
            }

            if (string.IsNullOrWhiteSpace(editAsphaltMixtureServiceModel.Type))
            {
                throw new ArgumentNullException(EmptyAsphaltMixtureErrorMessage);
            }

            if (await this.context.AsphaltMixtures.AnyAsync(am => am.Type == editAsphaltMixtureServiceModel.Type))
            {
                throw new InvalidOperationException(AsphaltMixtureExistErrorMessage);
            }

            if (editAsphaltMixtureServiceModel.Type.Length > AttributesConstraints.AsphaltMixtureTypeMaxLength)
            {
                throw new InvalidOperationException(string.Format(AsphaltMixtureTypeMaxLengthErrorMessage, AttributesConstraints.AsphaltMixtureTypeMaxLength));
            }

            asphaltMixture.Type = editAsphaltMixtureServiceModel.Type;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.AsphaltMixtures.AnyAsync(am => am.Id == id);
        }

        public async Task<AsphaltMixture> GetByIdAsync(int id)
        {
            await this.context.AsphaltMixtures.Include(am => am.Courses).ToListAsync();

            var asphaltMixture = await this.context
                .AsphaltMixtures
                .FindAsync(id);

            if (asphaltMixture == null)
            {
                throw new ArgumentNullException(string.Format(InvalidAsphaltMixtureIdErrorMessage, id));
            }

            return asphaltMixture;
        }
    }
}
