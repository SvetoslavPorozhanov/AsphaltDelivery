namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class RoadObjectsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.RoadObjects.AnyAsync())
            {
                return;
            }

            for (int i = 1; i <= 3; i++)
            {
                await dbContext.RoadObjects.AddAsync(new RoadObject { Name = $"Road object name {i}" });
            }
        }
    }
}
