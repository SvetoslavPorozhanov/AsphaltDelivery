namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class DriversSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Drivers.AnyAsync())
            {
                return;
            }

            for (int i = 1; i <= 10; i++)
            {
                await dbContext.Drivers.AddAsync(new Driver { FullName = $"Pesho Peshov {i}" });
            }
        }
    }
}
