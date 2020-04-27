namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class AsphaltBasesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.AsphaltBases.AnyAsync())
            {
                return;
            }

            for (int i = 1; i <= 3; i++)
            {
                await dbContext.AsphaltBases.AddAsync(new AsphaltBase { Name = $"Asphalt base name {i}" });
            }
        }
    }
}
