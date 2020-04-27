namespace AsphaltDelivery.Services.Data.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CourseService : ICourseService
    {
        private const string EmptyCourseErrorMessage = "One or more required properties are null.";
        private const string EmptyArchiveErrorMessage = "One or more required properties are null.";
        private const string CourseExistErrorMessage = "The combination of course's datetime and asphalt base properties must be unique.";
        private const string CourseWeightErrorMessage = "Course's weight must be between {0} and {1} tons.";
        private const string CourseDistanceErrorMessage = "Course's distance must be between {0} and {1} km.";
        private const string InvalidCourseIdErrorMessage = "Course with ID: {0} does not exist.";
        private const string InvalidDriverTruckCombinationErrorMessage = "Driver and truck should be from the same firm.";
        private const string InvalidDriverTruckFirmCombinationErrorMessage = "Driver and/or truck already have another firm.";
        private readonly ApplicationDbContext context;

        public CourseService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Course>> All()
        {
            await this.context.Courses.Include(c => c.Driver).ToListAsync();
            await this.context.Courses.Include(c => c.Truck).ToListAsync();
            await this.context.Courses.Include(c => c.Firm).ToListAsync();
            await this.context.Courses.Include(c => c.AsphaltBase).ToListAsync();
            await this.context.Courses.Include(c => c.AsphaltMixture).ToListAsync();
            await this.context.Courses.Include(c => c.RoadObject).ToListAsync();

            return await this.context
                .Courses.Where(c => c.IsDeleted == false).ToListAsync();
        }

        public IEnumerable<AllCoursesServiceModel> AllToCoursesServiceModel()
        {
            return this.context
                .Courses.Where(c => c.IsDeleted == false).To<AllCoursesServiceModel>();
        }

        public async Task ArchivateAsync(ArchivateCourseServiceModel archivateCourseServiceModel)
        {
            var coursesToArchivate = await this.context.Courses.ToArrayAsync();

            if (archivateCourseServiceModel.ArchivateFromYear == null || archivateCourseServiceModel.ArchivateToYear == null)
            {
                throw new ArgumentNullException(EmptyArchiveErrorMessage);
            }

            coursesToArchivate = coursesToArchivate.Where(c => c.DateTime.Year.CompareTo(archivateCourseServiceModel.ArchivateFromYear.Year) >= 0).ToArray();
            coursesToArchivate = coursesToArchivate.Where(c => c.DateTime.Year.CompareTo(archivateCourseServiceModel.ArchivateToYear.Year) <= 0).ToArray();

            foreach (var course in coursesToArchivate)
            {
                course.IsDeleted = true;
                course.DeletedOn = DateTime.UtcNow;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task UnarchivateAsync(UnarchivateCourseServiceModel unarchivateCourseServiceModel)
        {
            var coursesToUnarchivate = await this.context.Courses.ToArrayAsync();

            if (unarchivateCourseServiceModel.UnarchivateFromYear == null || unarchivateCourseServiceModel.UnarchivateToYear == null)
            {
                throw new ArgumentNullException(EmptyArchiveErrorMessage);
            }

            coursesToUnarchivate = coursesToUnarchivate.Where(c => c.DateTime.Year.CompareTo(unarchivateCourseServiceModel.UnarchivateFromYear.Year) >= 0).ToArray();
            coursesToUnarchivate = coursesToUnarchivate.Where(c => c.DateTime.Year.CompareTo(unarchivateCourseServiceModel.UnarchivateToYear.Year) <= 0).ToArray();

            foreach (var course in coursesToUnarchivate)
            {
                course.IsDeleted = false;
                course.DeletedOn = null;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task CreateAsync(CreateCourseServiceModel createCourseServiceModel)
        {
            var course = AutoMapperConfig.MapperInstance.Map<Course>(createCourseServiceModel);

            if (course.DateTime == null ||
                !this.context.Drivers.Select(d => d.Id).ContainsAsync(course.DriverId).GetAwaiter().GetResult() ||
                !this.context.Trucks.Select(d => d.Id).ContainsAsync(course.TruckId).GetAwaiter().GetResult() ||
                !this.context.Firms.Select(d => d.Id).ContainsAsync(course.FirmId).GetAwaiter().GetResult() ||
                !this.context.AsphaltBases.Select(d => d.Id).ContainsAsync(course.AsphaltBaseId).GetAwaiter().GetResult() ||
                !this.context.AsphaltMixtures.Select(d => d.Id).ContainsAsync(course.AsphaltMixtureId).GetAwaiter().GetResult() ||
                !this.context.RoadObjects.Select(d => d.Id).ContainsAsync(course.RoadObjectId).GetAwaiter().GetResult() ||
                course.Weight == 0 ||
                course.TransportDistance == 0)
            {
                throw new ArgumentNullException(EmptyCourseErrorMessage);
            }

            if (await this.context.Courses.AnyAsync(c => c.DateTime == course.DateTime && c.AsphaltBaseId == course.AsphaltBaseId))
            {
                throw new InvalidOperationException(CourseExistErrorMessage);
            }

            if (course.Weight > double.Parse(AttributesConstraints.MaxCourseWeight) ||
                course.Weight < double.Parse(AttributesConstraints.MinCourseWeight))
            {
                throw new InvalidOperationException(string.Format(CourseWeightErrorMessage, AttributesConstraints.MinCourseWeight, AttributesConstraints.MaxCourseWeight));
            }

            if (course.TransportDistance > AttributesConstraints.MaxCourseDistance ||
                course.TransportDistance < AttributesConstraints.MinCourseDistance)
            {
                throw new InvalidOperationException(string.Format(CourseDistanceErrorMessage, AttributesConstraints.MinCourseDistance, AttributesConstraints.MaxCourseDistance));
            }

            var driverFirmFromDb = await this.context.Drivers.Where(d => d.Id == course.DriverId).Select(d => d.Firm).FirstOrDefaultAsync();
            var truckFirmFromDb = await this.context.Trucks.Where(t => t.Id == course.TruckId).Select(t => t.Firm).FirstOrDefaultAsync();

            if (driverFirmFromDb?.Id != null && truckFirmFromDb?.Id != null && driverFirmFromDb?.Id != truckFirmFromDb?.Id)
            {
                throw new InvalidOperationException(InvalidDriverTruckCombinationErrorMessage);
            }

            if (driverFirmFromDb?.Id != null && truckFirmFromDb?.Id != null && driverFirmFromDb?.Id == truckFirmFromDb?.Id && driverFirmFromDb?.Id != course.FirmId)
            {
                throw new InvalidOperationException(InvalidDriverTruckFirmCombinationErrorMessage);
            }

            if (driverFirmFromDb == null && truckFirmFromDb?.Id != null && truckFirmFromDb?.Id != course.FirmId)
            {
                throw new InvalidOperationException(InvalidDriverTruckFirmCombinationErrorMessage);
            }

            if (driverFirmFromDb?.Id != null && truckFirmFromDb == null && driverFirmFromDb?.Id != course.FirmId)
            {
                throw new InvalidOperationException(InvalidDriverTruckFirmCombinationErrorMessage);
            }

            var firm = await this.context.Firms.Where(f => f.Id == course.FirmId).FirstOrDefaultAsync();
            var driver = await this.context.Drivers.Where(d => d.Id == course.DriverId).FirstOrDefaultAsync();
            var truck = await this.context.Trucks.Where(t => t.Id == course.TruckId).FirstOrDefaultAsync();

            if (!firm.Drivers.Any(d => d.Id == driver.Id))
            {
                // driver.FirmId = course.FirmId;
                firm.Drivers.Add(driver);
            }

            if (!firm.Trucks.Any(t => t.Id == truck.Id))
            {
                firm.Trucks.Add(truck);
            }

            if (!await this.context.TruckDrivers.AnyAsync(td => td.TruckId == course.TruckId && td.DriverId == course.DriverId))
            {
                this.context.TruckDrivers.Add(new TruckDriver
                {
                    Truck = truck,
                    Driver = driver,
                });
            }

            await this.context.Courses.AddAsync(course);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var course = await this.context
                .Courses
                .FindAsync(id);

            if (course == null)
            {
                throw new ArgumentNullException(string.Format(InvalidCourseIdErrorMessage, id));
            }

            if (await this.context.Courses.Where(c => c.DriverId == course.DriverId && c.TruckId == course.TruckId && c.FirmId == course.FirmId).CountAsync() == 1)
            {
                var firm = await this.context.Firms.Where(f => f.Id == course.FirmId).FirstOrDefaultAsync();
                var driver = await this.context.Drivers.Where(d => d.Id == course.DriverId).FirstOrDefaultAsync();
                var truck = await this.context.Trucks.Where(t => t.Id == course.TruckId).FirstOrDefaultAsync();

                firm.Drivers.Remove(driver);
                firm.Trucks.Remove(truck);

                var driverTruckToRemove = this.context.TruckDrivers.FirstOrDefault(dt => dt.DriverId == driver.Id && dt.TruckId == truck.Id);

                this.context.TruckDrivers.Remove(driverTruckToRemove);
            }

            this.context.Courses.Remove(course);
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(EditCourseServiceModel editCourseServiceModel)
        {
            var course = await this.context
                .Courses
                .FindAsync(editCourseServiceModel.Id);

            if (course == null)
            {
                throw new ArgumentNullException(string.Format(InvalidCourseIdErrorMessage, editCourseServiceModel.Id));
            }

            if (course.DateTime == null ||
                !this.context.Drivers.Select(d => d.Id).ContainsAsync(editCourseServiceModel.DriverId).GetAwaiter().GetResult() ||
                !this.context.Trucks.Select(d => d.Id).ContainsAsync(editCourseServiceModel.TruckId).GetAwaiter().GetResult() ||
                !this.context.Firms.Select(d => d.Id).ContainsAsync(editCourseServiceModel.FirmId).GetAwaiter().GetResult() ||
                !this.context.AsphaltBases.Select(d => d.Id).ContainsAsync(editCourseServiceModel.AsphaltBaseId).GetAwaiter().GetResult() ||
                !this.context.AsphaltMixtures.Select(d => d.Id).ContainsAsync(editCourseServiceModel.AsphaltMixtureId).GetAwaiter().GetResult() ||
                !this.context.RoadObjects.Select(d => d.Id).ContainsAsync(editCourseServiceModel.RoadObjectId).GetAwaiter().GetResult() ||
                course.Weight == 0 ||
                course.TransportDistance == 0)
            {
                throw new ArgumentNullException(EmptyCourseErrorMessage);
            }

            if (await this.context.Courses.Where(c => c.DateTime == editCourseServiceModel.DateTime && c.AsphaltBaseId == editCourseServiceModel.AsphaltBaseId).CountAsync() >= 1 &&
                (course.DateTime.CompareTo(editCourseServiceModel.DateTime) != 0 || course.AsphaltBaseId != editCourseServiceModel.AsphaltBaseId))
            {
                throw new InvalidOperationException(CourseExistErrorMessage);
            }

            if (editCourseServiceModel.Weight > double.Parse(AttributesConstraints.MaxCourseWeight) ||
                editCourseServiceModel.Weight < double.Parse(AttributesConstraints.MinCourseWeight))
            {
                throw new InvalidOperationException(string.Format(CourseWeightErrorMessage, AttributesConstraints.MinCourseWeight, AttributesConstraints.MaxCourseWeight));
            }

            if (editCourseServiceModel.TransportDistance > AttributesConstraints.MaxCourseDistance ||
                editCourseServiceModel.TransportDistance < AttributesConstraints.MinCourseDistance)
            {
                throw new InvalidOperationException(string.Format(CourseDistanceErrorMessage, AttributesConstraints.MinCourseDistance, AttributesConstraints.MaxCourseDistance));
            }

            var firm = await this.context.Firms.Where(f => f.Id == course.FirmId).FirstOrDefaultAsync();
            var driver = await this.context.Drivers.Where(d => d.Id == course.DriverId).FirstOrDefaultAsync();
            var truck = await this.context.Trucks.Where(t => t.Id == course.TruckId).FirstOrDefaultAsync();

            if ((course.DriverId != editCourseServiceModel.DriverId || course.TruckId != editCourseServiceModel.TruckId) &&
                await this.context.Courses.Where(c => c.DriverId == course.DriverId && c.TruckId == course.TruckId && c.FirmId == course.FirmId).CountAsync() == 1)
            {
                firm.Drivers.Remove(driver);
                firm.Trucks.Remove(truck);

                var driverTruckToRemove = this.context.TruckDrivers.FirstOrDefault(dt => dt.DriverId == driver.Id && dt.TruckId == truck.Id);

                // driver.DriverTrucks.Remove(driverTruckToRemove);

                // truck.TruckDrivers.Remove(driverTruckToRemove);

                // Doesn't remove?
                this.context.TruckDrivers.Remove(driverTruckToRemove);
            }

            var driverFirmFromDb = await this.context.Drivers.Where(d => d.Id == editCourseServiceModel.DriverId).Select(d => d.Firm).FirstOrDefaultAsync();
            var truckFirmFromDb = await this.context.Trucks.Where(t => t.Id == editCourseServiceModel.TruckId).Select(t => t.Firm).FirstOrDefaultAsync();

            if (driverFirmFromDb?.Id != null && truckFirmFromDb?.Id != null && driverFirmFromDb?.Id != truckFirmFromDb?.Id)
            {
                throw new InvalidOperationException(InvalidDriverTruckCombinationErrorMessage);
            }

            if (driverFirmFromDb?.Id != null && truckFirmFromDb?.Id != null && driverFirmFromDb?.Id == truckFirmFromDb?.Id && driverFirmFromDb?.Id != editCourseServiceModel.FirmId)
            {
                throw new InvalidOperationException(InvalidDriverTruckFirmCombinationErrorMessage);
            }

            if (driverFirmFromDb == null && truckFirmFromDb?.Id != null && truckFirmFromDb?.Id != editCourseServiceModel.FirmId)
            {
                throw new InvalidOperationException(InvalidDriverTruckFirmCombinationErrorMessage);
            }

            if (driverFirmFromDb?.Id != null && truckFirmFromDb == null && driverFirmFromDb?.Id != editCourseServiceModel.FirmId)
            {
                throw new InvalidOperationException(InvalidDriverTruckFirmCombinationErrorMessage);
            }

            var newDriver = await this.context.Drivers.FirstOrDefaultAsync(d => d.Id == editCourseServiceModel.DriverId);
            var newTruck = await this.context.Trucks.FirstOrDefaultAsync(t => t.Id == editCourseServiceModel.TruckId);
            var newFirm = await this.context.Firms.FirstOrDefaultAsync(f => f.Id == editCourseServiceModel.FirmId);

            if (!newFirm.Drivers.Any(d => d.Id == newDriver.Id))
            {
                // driver.FirmId = course.FirmId;
                newFirm.Drivers.Add(newDriver);
            }

            if (!newFirm.Trucks.Any(t => t.Id == newTruck.Id))
            {
                newFirm.Trucks.Add(newTruck);
            }

            if (!await this.context.TruckDrivers.AnyAsync(td => td.DriverId == newDriver.Id && td.TruckId == newTruck.Id))
            {
                newTruck.TruckDrivers.Add(new TruckDriver
                {
                    Truck = newTruck,
                    Driver = newDriver,
                });
            }

            if (course.DateTime != editCourseServiceModel.DateTime)
            {
                course.DateTime = editCourseServiceModel.DateTime;
            }

            if (course.DriverId != editCourseServiceModel.DriverId)
            {
                course.DriverId = editCourseServiceModel.DriverId;
            }

            if (course.TruckId != editCourseServiceModel.TruckId)
            {
                course.TruckId = editCourseServiceModel.TruckId;
            }

            if (course.FirmId != editCourseServiceModel.FirmId)
            {
                course.FirmId = editCourseServiceModel.FirmId;
            }

            if (course.AsphaltBaseId != editCourseServiceModel.AsphaltBaseId)
            {
                course.AsphaltBaseId = editCourseServiceModel.AsphaltBaseId;
            }

            if (course.AsphaltMixtureId != editCourseServiceModel.AsphaltMixtureId)
            {
                course.AsphaltMixtureId = editCourseServiceModel.AsphaltMixtureId;
            }

            if (course.RoadObjectId != editCourseServiceModel.RoadObjectId)
            {
                course.RoadObjectId = editCourseServiceModel.RoadObjectId;
            }

            if (course.Weight != editCourseServiceModel.Weight)
            {
                course.Weight = editCourseServiceModel.Weight;
            }

            if (course.TransportDistance != editCourseServiceModel.TransportDistance)
            {
                course.TransportDistance = editCourseServiceModel.TransportDistance;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            await this.context.Courses.Include(c => c.Driver).ToListAsync();
            await this.context.Courses.Include(c => c.Truck).ToListAsync();
            await this.context.Courses.Include(c => c.Firm).ToListAsync();
            await this.context.Courses.Include(c => c.AsphaltBase).ToListAsync();
            await this.context.Courses.Include(c => c.AsphaltMixture).ToListAsync();
            await this.context.Courses.Include(c => c.RoadObject).ToListAsync();

            var course = await this.context
                .Courses
                .FindAsync(id);

            if (course == null)
            {
                throw new ArgumentNullException(string.Format(InvalidCourseIdErrorMessage, id));
            }

            return course;
        }
    }
}
