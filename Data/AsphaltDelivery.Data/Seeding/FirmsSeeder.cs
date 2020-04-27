namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class FirmsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Firms.AnyAsync())
            {
                return;
            }

            for (int i = 1; i <= 5; i++)
            {
                await dbContext.Firms.AddAsync(new Firm { Name = $"Firm Name {i}" });
            }
        }
    }
}
