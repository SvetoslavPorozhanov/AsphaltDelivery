namespace AsphaltDelivery.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class PicturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Pictures.AnyAsync())
            {
                return;
            }

            await dbContext.Pictures.AddAsync(new Picture { Uri = "https://res.cloudinary.com/asphaltdelivery/image/upload/v1585248530/Truck_kjh3ry.jpg" });
        }
    }
}
