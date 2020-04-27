namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Pictures;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using Xunit;

    public class PictureServiceTests
    {
        [Fact]
        public async Task ChangePictureAsync_ShouldChangeSuccessfully()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var pictureService = new PictureService(context);
            var picture = await pictureService.GetPictureAsync();
            picture.Uri = "Uri 2";
            await pictureService.ChangePictureAsync(picture);

            var expectedResult = "Uri 2";
            var actualResultAsPicture = await context.Pictures.FindAsync(1);
            var actualResult = actualResultAsPicture.Uri;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task ChangePictureAsyncWithEmptyUri_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var pictureService = new PictureService(context);
            var picture = await pictureService.GetPictureAsync();
            picture.Uri = "  ";

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await pictureService.ChangePictureAsync(picture);
            });
        }

        [Fact]
        public async Task GetPictureAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var pictureService = new PictureService(context);
            var picture = await pictureService.GetPictureAsync();
            var expectedResult = "Uri 1";
            var actualResult = picture.Uri;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task GetPictureAsyncWithNoPicture_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var pictureService = new PictureService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await pictureService.GetPictureAsync();
            });
        }

        private Picture GetDummyData()
        {
            return new Picture() { Uri = "Uri 1" };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.Add(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
