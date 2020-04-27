namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class AsphaltMixturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.AsphaltMixtures.AnyAsync())
            {
                return;
            }

            await dbContext.AsphaltMixtures.AddAsync(new AsphaltMixture { Type = "Asphalt surface" });
            await dbContext.AsphaltMixtures.AddAsync(new AsphaltMixture { Type = "Asphalt binder layer" });
            await dbContext.AsphaltMixtures.AddAsync(new AsphaltMixture { Type = "Asphalt base layer" });
        }
    }
}
