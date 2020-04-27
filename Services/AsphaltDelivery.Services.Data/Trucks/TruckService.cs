namespace AsphaltDelivery.Services.Data.Trucks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class TruckService : ITruckService
    {
        private const string EmptyTruckErrorMessage = "One or more required properties are null.";
        private const string TruckExistErrorMessage = "Truck's Registration number already exists.";
        private const string TruckRegistrationNumberMaxLengthErrorMessage = "Truck's Registration number cannot be more than {0} characters.";
        private const string InvalidTruckIdErrorMessage = "Truck with ID: {0} does not exist.";
        private readonly ApplicationDbContext context;

        public TruckService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Truck> All()
        {
            return this.context.Trucks;
        }

        public async Task CreateAsync(CreateTruckServiceModel createTruckServiceModel)
        {
            var truck = AutoMapperConfig.MapperInstance.Map<Truck>(createTruckServiceModel);

            if (string.IsNullOrWhiteSpace(truck.RegistrationNumber))
            {
                throw new ArgumentNullException(EmptyTruckErrorMessage);
            }

            if (await this.context.Trucks.AnyAsync(t => t.RegistrationNumber == truck.RegistrationNumber))
            {
                throw new InvalidOperationException(TruckExistErrorMessage);
            }

            if (truck.RegistrationNumber.Length > AttributesConstraints.TruckRegistrationNumberMaxLength)
            {
                throw new InvalidOperationException(string.Format(TruckRegistrationNumberMaxLengthErrorMessage, AttributesConstraints.TruckRegistrationNumberMaxLength));
            }

            await this.context.Trucks.AddAsync(truck);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var truck = await this.context
                .Trucks
                .FindAsync(id);

            if (truck == null)
            {
                throw new ArgumentNullException(string.Format(InvalidTruckIdErrorMessage, id));
            }

            this.context.Trucks.Remove(truck); // Cascade restrict error?
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditTruckServiceModel editTruckServiceModel)
        {
            var truck = await this.context
                .Trucks
                .FindAsync(editTruckServiceModel.Id);

            if (truck == null)
            {
                throw new ArgumentNullException(string.Format(InvalidTruckIdErrorMessage, editTruckServiceModel.Id));
            }

            if (string.IsNullOrWhiteSpace(editTruckServiceModel.RegistrationNumber))
            {
                throw new ArgumentNullException(EmptyTruckErrorMessage);
            }

            if (await this.context.Trucks.AnyAsync(t => t.RegistrationNumber == editTruckServiceModel.RegistrationNumber))
            {
                throw new InvalidOperationException(TruckExistErrorMessage);
            }

            if (editTruckServiceModel.RegistrationNumber.Length > AttributesConstraints.TruckRegistrationNumberMaxLength)
            {
                throw new InvalidOperationException(string.Format(TruckRegistrationNumberMaxLengthErrorMessage, AttributesConstraints.TruckRegistrationNumberMaxLength));
            }

            truck.RegistrationNumber = editTruckServiceModel.RegistrationNumber;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Trucks.AnyAsync(t => t.Id == id);
        }

        public async Task<Truck> GetByIdAsync(int id)
        {
            await this.context.Trucks.Include(t => t.Courses).ToListAsync();
            await this.context.Trucks.Include(t => t.TruckDrivers).ThenInclude(td => td.Driver).ToListAsync();
            await this.context.Trucks.Include(t => t.Firm).ToListAsync();

            var truck = await this.context
                .Trucks
                .FindAsync(id);

            if (truck == null)
            {
                throw new ArgumentNullException(string.Format(InvalidTruckIdErrorMessage, id));
            }

            return truck;
        }
    }
}
