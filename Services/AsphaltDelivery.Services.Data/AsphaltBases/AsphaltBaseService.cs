namespace AsphaltDelivery.Services.Data.AsphaltBases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class AsphaltBaseService : IAsphaltBaseService
    {
        private const string EmptyAsphaltBaseErrorMessage = "One or more required properties are null.";
        private const string AsphaltBaseExistErrorMessage = "Asphalt base's name already exists.";
        private const string AsphaltBaseNameMaxLengthErrorMessage = "Asphalt base's name cannot be more than {0} characters.";
        private const string InvalidAsphaltBaseIdErrorMessage = "Asphalt base with ID: {0} does not exist.";
        private readonly ApplicationDbContext context;

        public AsphaltBaseService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<AsphaltBase> All()
        {
            return this.context.AsphaltBases;
        }

        public async Task CreateAsync(CreateAsphaltBaseServiceModel createAsphaltBaseServiceModel)
        {
            var asphaltBase = AutoMapperConfig.MapperInstance.Map<AsphaltBase>(createAsphaltBaseServiceModel);

            if (string.IsNullOrWhiteSpace(asphaltBase.Name))
            {
                throw new ArgumentNullException(EmptyAsphaltBaseErrorMessage);
            }

            if (await this.context.AsphaltBases.AnyAsync(ab => ab.Name == asphaltBase.Name))
            {
                throw new InvalidOperationException(AsphaltBaseExistErrorMessage);
            }

            if (asphaltBase.Name.Length > AttributesConstraints.AsphaltBaseNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(AsphaltBaseNameMaxLengthErrorMessage, AttributesConstraints.AsphaltBaseNameMaxLength));
            }

            await this.context.AsphaltBases.AddAsync(asphaltBase);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var asphaltBase = await this.context
                .AsphaltBases
                .FindAsync(id);

            if (asphaltBase == null)
            {
                throw new ArgumentNullException(string.Format(InvalidAsphaltBaseIdErrorMessage, id));
            }

            this.context.AsphaltBases.Remove(asphaltBase); // Cascade restrict error?
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditAsphaltBaseServiceModel editAsphaltBaseServiceModel)
        {
            var asphaltBase = await this.context
                .AsphaltBases
                .FindAsync(editAsphaltBaseServiceModel.Id);

            if (asphaltBase == null)
            {
                throw new ArgumentNullException(string.Format(InvalidAsphaltBaseIdErrorMessage, editAsphaltBaseServiceModel.Id));
            }

            if (string.IsNullOrWhiteSpace(editAsphaltBaseServiceModel.Name))
            {
                throw new ArgumentNullException(EmptyAsphaltBaseErrorMessage);
            }

            if (await this.context.AsphaltBases.AnyAsync(ab => ab.Name == editAsphaltBaseServiceModel.Name))
            {
                throw new InvalidOperationException(AsphaltBaseExistErrorMessage);
            }

            if (editAsphaltBaseServiceModel.Name.Length > AttributesConstraints.AsphaltBaseNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(AsphaltBaseNameMaxLengthErrorMessage, AttributesConstraints.AsphaltBaseNameMaxLength));
            }

            asphaltBase.Name = editAsphaltBaseServiceModel.Name;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.AsphaltBases.AnyAsync(ab => ab.Id == id);
        }

        public async Task<AsphaltBase> GetByIdAsync(int id)
        {
            await this.context.AsphaltBases.Include(ab => ab.Courses).ToListAsync();

            var asphaltBase = await this.context
                .AsphaltBases
                .FindAsync(id);

            if (asphaltBase == null)
            {
                throw new ArgumentNullException(string.Format(InvalidAsphaltBaseIdErrorMessage, id));
            }

            return asphaltBase;
        }
    }
}
