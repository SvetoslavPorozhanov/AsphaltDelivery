namespace AsphaltDelivery.Services.Data.Firms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class FirmService : IFirmService
    {
        private const string EmptyFirmErrorMessage = "One or more required properties are null.";
        private const string FirmExistErrorMessage = "Firm's name already exists.";
        private const string FirmNameMaxLengthErrorMessage = "Firm's Name cannot be more than {0} characters.";
        private const string InvalidFirmIdErrorMessage = "Firm with ID: {0} does not exist.";
        private readonly ApplicationDbContext context;

        public FirmService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Firm> All()
        {
            return this.context.Firms;
        }

        public async Task CreateAsync(CreateFirmServiceModel createFirmServiceModel)
        {
            var firm = AutoMapperConfig.MapperInstance.Map<Firm>(createFirmServiceModel);

            if (string.IsNullOrWhiteSpace(firm.Name))
            {
                throw new ArgumentNullException(EmptyFirmErrorMessage);
            }

            if (await this.context.Firms.AnyAsync(f => f.Name == firm.Name))
            {
                throw new InvalidOperationException(FirmExistErrorMessage);
            }

            if (firm.Name.Length > AttributesConstraints.FirmNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(FirmNameMaxLengthErrorMessage, AttributesConstraints.FirmNameMaxLength));
            }

            await this.context.Firms.AddAsync(firm);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var firm = await this.context
                .Firms
                .FindAsync(id);

            if (firm == null)
            {
                throw new ArgumentNullException(string.Format(InvalidFirmIdErrorMessage, id));
            }

            this.context.Firms.Remove(firm); // Cascade restrict error?
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditFirmServiceModel editFirmServiceModel)
        {
            var firm = await this.context
                .Firms
                .FindAsync(editFirmServiceModel.Id);

            if (firm == null)
            {
                throw new ArgumentNullException(string.Format(InvalidFirmIdErrorMessage, editFirmServiceModel.Id));
            }

            if (string.IsNullOrWhiteSpace(editFirmServiceModel.Name))
            {
                throw new ArgumentNullException(EmptyFirmErrorMessage);
            }

            if (await this.context.Firms.AnyAsync(f => f.Name == editFirmServiceModel.Name))
            {
                throw new InvalidOperationException(FirmExistErrorMessage);
            }

            if (editFirmServiceModel.Name.Length > AttributesConstraints.FirmNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(FirmNameMaxLengthErrorMessage, AttributesConstraints.FirmNameMaxLength));
            }

            firm.Name = editFirmServiceModel.Name;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Firms.AnyAsync(f => f.Id == id);
        }

        public async Task<Firm> GetByIdAsync(int id)
        {
            await this.context.Firms.Include(f => f.Courses).ToListAsync();
            await this.context.Firms.Include(f => f.Drivers).ToListAsync();
            await this.context.Firms.Include(f => f.Trucks).ToListAsync();

            var firm = await this.context
                .Firms
                .FindAsync(id);

            if (firm == null)
            {
                throw new ArgumentNullException(string.Format(InvalidFirmIdErrorMessage, id));
            }

            return firm;
        }
    }
}
