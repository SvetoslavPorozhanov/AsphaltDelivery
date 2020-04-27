namespace AsphaltDelivery.Services.Data.Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class DriverService : IDriverService
    {
        private const string EmptyDriverErrorMessage = "One or more required properties are null.";
        private const string DriverExistErrorMessage = "Driver's fullname already exists.";
        private const string DriverFullNameMaxLengthErrorMessage = "Driver's fullname cannot be more than {0} characters.";
        private const string InvalidDriverIdErrorMessage = "Driver with ID: {0} does not exist.";
        private readonly ApplicationDbContext context;

        public DriverService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Driver> All()
        {
            return this.context.Drivers;
        }

        public async Task CreateAsync(CreateDriverServiceModel createDriverServiceModel)
        {
            var driver = AutoMapperConfig.MapperInstance.Map<Driver>(createDriverServiceModel);

            if (string.IsNullOrWhiteSpace(driver.FullName))
            {
                throw new ArgumentNullException(EmptyDriverErrorMessage);
            }

            if (await this.context.Drivers.AnyAsync(d => d.FullName == driver.FullName))
            {
                throw new InvalidOperationException(DriverExistErrorMessage);
            }

            if (driver.FullName.Length > AttributesConstraints.DriverFullNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(DriverFullNameMaxLengthErrorMessage, AttributesConstraints.DriverFullNameMaxLength));
            }

            await this.context.Drivers.AddAsync(driver);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var driver = await this.context
                .Drivers
                .FindAsync(id);

            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(InvalidDriverIdErrorMessage, id));
            }

            this.context.Drivers.Remove(driver); // Cascade restrict error?
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditDriverServiceModel editDriverServiceModel)
        {
            var driver = await this.context
                .Drivers
                .FindAsync(editDriverServiceModel.Id);

            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(InvalidDriverIdErrorMessage, editDriverServiceModel.Id));
            }

            if (string.IsNullOrWhiteSpace(editDriverServiceModel.FullName))
            {
                throw new ArgumentNullException(EmptyDriverErrorMessage);
            }

            if (await this.context.Drivers.AnyAsync(d => d.FullName == editDriverServiceModel.FullName))
            {
                throw new InvalidOperationException(DriverExistErrorMessage);
            }

            if (editDriverServiceModel.FullName.Length > AttributesConstraints.DriverFullNameMaxLength)
            {
                throw new InvalidOperationException(string.Format(DriverFullNameMaxLengthErrorMessage, AttributesConstraints.DriverFullNameMaxLength));
            }

            driver.FullName = editDriverServiceModel.FullName;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Drivers.AnyAsync(d => d.Id == id);
        }

        public async Task<Driver> GetByIdAsync(int id)
        {
            // Eager loading
            await this.context.Drivers.Include(d => d.Courses).ToListAsync();
            await this.context.Drivers.Include(d => d.DriverTrucks).ThenInclude(dt => dt.Truck).ToListAsync();
            await this.context.Drivers.Include(d => d.Firm).ToListAsync();

            var driver = await this.context
               .Drivers
               .FindAsync(id);

            // With projection?
            //var driver = from d in this.context.Drivers
            //             select new Driver
            //             {
            //                 Id = d.Id,
            //                 FullName = d.FullName,
            //                 Firm = d.Firm,
            //                 Courses = d.Courses.Select(c => new Course
            //                 {
            //                     Id = c.Id,
            //                 }).ToList(),
            //                 DriverTrucks = d.DriverTrucks.Select(dt => new TruckDriver
            //                 {
            //                     Driver = dt.Driver,
            //                     Truck = dt.Truck,
            //                 }).ToList(),
            //             };

            // var driver = AutoMapperConfig.MapperInstance.Map<Driver>(driver);

            // Explicit loading
            // await this.context.Entry(driver).Collection(d => d.Courses).LoadAsync();
            // await this.context.Entry(driver).Reference(d => d.Firm).LoadAsync();
            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(InvalidDriverIdErrorMessage, id));
            }

            return driver;
        }
    }
}
