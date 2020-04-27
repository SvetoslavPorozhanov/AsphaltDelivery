namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class TrucksSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Trucks.AnyAsync())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                await dbContext.Trucks.AddAsync(new Truck { RegistrationNumber = $"CA000{i}CA" });
            }
        }
    }
}
