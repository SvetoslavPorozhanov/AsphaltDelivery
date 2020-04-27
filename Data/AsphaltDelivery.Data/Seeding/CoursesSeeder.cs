namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class CoursesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Courses.AnyAsync())
            {
                return;
            }

            Random random = new Random();

            // 1 Entry
            await dbContext.Courses.AddAsync(new Course
            {
                DateTime = DateTime.UtcNow,
                DriverId = 1,
                TruckId = 1,
                FirmId = 1,
                AsphaltMixtureId = 2,
                AsphaltBaseId = 1,
                RoadObjectId = 3,
                TransportDistance = random.Next(1, 51),
                Weight = random.NextDouble() * 30,
            });

            Truck truck1 = await dbContext.Trucks.FirstOrDefaultAsync(t => t.Id == 1);
            Driver driver1 = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == 1);

            truck1.TruckDrivers.Add(new TruckDriver
            {
                Driver = driver1,
            });

            Firm firm1 = await dbContext.Firms.FirstOrDefaultAsync(f => f.Id == 1);

            firm1.Drivers.Add(driver1);
            firm1.Trucks.Add(truck1);

            // 2 Entry
            await dbContext.Courses.AddAsync(new Course
            {
                DateTime = DateTime.UtcNow.AddDays(5),
                DriverId = 2,
                TruckId = 2,
                FirmId = 2,
                AsphaltMixtureId = 1,
                AsphaltBaseId = 2,
                RoadObjectId = 1,
                TransportDistance = random.Next(1, 51),
                Weight = random.NextDouble() * 30,
            });

            Truck truck2 = await dbContext.Trucks.FirstOrDefaultAsync(t => t.Id == 2);
            Driver driver2 = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == 2);

            truck2.TruckDrivers.Add(new TruckDriver
            {
                Driver = driver2,
                Truck = truck2,
            });

            Firm firm2 = await dbContext.Firms.FirstOrDefaultAsync(f => f.Id == 2);

            firm2.Drivers.Add(driver2);
            firm2.Trucks.Add(truck2);

            // 3 Entry
            await dbContext.Courses.AddAsync(new Course
            {
                DateTime = DateTime.UtcNow.AddDays(10),
                DriverId = 3,
                TruckId = 3,
                FirmId = 3,
                AsphaltMixtureId = 3,
                AsphaltBaseId = 3,
                RoadObjectId = 2,
                TransportDistance = random.Next(1, 51),
                Weight = random.NextDouble() * 30,
            });

            Truck truck3 = await dbContext.Trucks.FirstOrDefaultAsync(t => t.Id == 3);
            Driver driver3 = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == 3);

            truck3.TruckDrivers.Add(new TruckDriver
            {
                Driver = driver3,
                Truck = truck3,
            });

            Firm firm3 = await dbContext.Firms.FirstOrDefaultAsync(f => f.Id == 3);

            firm3.Drivers.Add(driver3);
            firm3.Trucks.Add(truck3);

            // 4 Entry
            await dbContext.Courses.AddAsync(new Course
            {
                DateTime = DateTime.UtcNow.AddDays(15),
                DriverId = 4,
                TruckId = 4,
                FirmId = 4,
                AsphaltMixtureId = 2,
                AsphaltBaseId = 1,
                RoadObjectId = 3,
                TransportDistance = random.Next(1, 51),
                Weight = random.NextDouble() * 30,
            });

            Truck truck4 = await dbContext.Trucks.FirstOrDefaultAsync(t => t.Id == 4);
            Driver driver4 = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == 4);

            truck4.TruckDrivers.Add(new TruckDriver
            {
                Driver = driver4,
                Truck = truck4,
            });

            Firm firm4 = await dbContext.Firms.FirstOrDefaultAsync(f => f.Id == 4);

            firm4.Drivers.Add(driver4);
            firm4.Trucks.Add(truck4);

            // 5 Entry
            await dbContext.Courses.AddAsync(new Course
            {
                DateTime = DateTime.UtcNow.AddDays(20),
                DriverId = 5,
                TruckId = 5,
                FirmId = 5,
                AsphaltMixtureId = 1,
                AsphaltBaseId = 3,
                RoadObjectId = 1,
                TransportDistance = random.Next(1, 51),
                Weight = random.NextDouble() * 30,
            });

            Truck truck5 = await dbContext.Trucks.FirstOrDefaultAsync(t => t.Id == 5);
            Driver driver5 = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == 5);

            truck5.TruckDrivers.Add(new TruckDriver
            {
                Driver = driver5,
                Truck = truck5,
            });

            Firm firm5 = await dbContext.Firms.FirstOrDefaultAsync(f => f.Id == 5);

            firm5.Drivers.Add(driver5);
            firm5.Trucks.Add(truck5);
        }
    }
}
