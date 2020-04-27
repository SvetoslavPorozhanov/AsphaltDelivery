namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using Xunit;

    public class AsphaltMixtureServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);

            var actualResult = asphaltMixtureService.All().Select(x => x.Type).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Type).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResult[i]);
            }
        }

        [Fact]
        public void All_ShouldReturnEmptyResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltMixtureService = new AsphaltMixtureService(context);

            var actualResult = asphaltMixtureService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyCreate()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var createAsphaltMixtureServiceModel = new CreateAsphaltMixtureServiceModel();
            var asphaltMixtureType = "AMT 1";
            createAsphaltMixtureServiceModel.Type = asphaltMixtureType;

            await asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModel);
            var expectedResult = asphaltMixtureType;
            var actualResult = asphaltMixtureService
                .All()
                .First()
                .Type;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task CreateAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var createAsphaltMixtureServiceModel = new CreateAsphaltMixtureServiceModel();
            var asphaltMixtureType = "  ";
            createAsphaltMixtureServiceModel.Type = asphaltMixtureType;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var createAsphaltMixtureServiceModel = new CreateAsphaltMixtureServiceModel();
            var asphaltMixtureType = "AMT 1";
            createAsphaltMixtureServiceModel.Type = asphaltMixtureType;
            var message = "Asphalt mixture's type already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var createAsphaltMixtureServiceModel = new CreateAsphaltMixtureServiceModel();
            var asphaltMixtureType = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            createAsphaltMixtureServiceModel.Type = asphaltMixtureType;
            var message = "Asphalt mixture's type cannot be more than 30 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldSuccessfullyDelete()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var deleteAsphaltMixtureServiceModel = new DeleteAsphaltMixtureServiceModel();
            deleteAsphaltMixtureServiceModel.Id = 1;

            await asphaltMixtureService.DeleteByIdAsync(deleteAsphaltMixtureServiceModel.Id);
            var expectedResult = 1;
            var actualResult = asphaltMixtureService
                .All()
                .Count();
            var expectedResult2 = "AMT 2";
            var actualResult2 = asphaltMixtureService
                .All()
                .First()
                .Type;

            Assert.True(expectedResult == actualResult);
            Assert.True(expectedResult2 == actualResult2);
        }

        [Fact]
        public async Task DeleteByIdAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var deleteAsphaltMixtureServiceModel = new DeleteAsphaltMixtureServiceModel();
            deleteAsphaltMixtureServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltMixtureService.DeleteByIdAsync(deleteAsphaltMixtureServiceModel.Id);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldSuccessfullyEdit()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var editAsphaltMixtureServiceModel = new EditAsphaltMixtureServiceModel();
            var asphaltMixtureId = 1;
            var asphaltMixtureType = "AMT 3";
            editAsphaltMixtureServiceModel.Id = asphaltMixtureId;
            editAsphaltMixtureServiceModel.Type = asphaltMixtureType;

            await asphaltMixtureService.EditAsync(editAsphaltMixtureServiceModel);
            var expectedResult = asphaltMixtureType;
            var actualResult = asphaltMixtureService
                .All()
                .First()
                .Type;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var editAsphaltMixtureServiceModel = new EditAsphaltMixtureServiceModel();
            editAsphaltMixtureServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltMixtureService.EditAsync(editAsphaltMixtureServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var editAsphaltMixtureServiceModel = new EditAsphaltMixtureServiceModel();
            var asphaltMixtureType = "  ";
            editAsphaltMixtureServiceModel.Type = asphaltMixtureType;
            editAsphaltMixtureServiceModel.Id = 1;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltMixtureService.EditAsync(editAsphaltMixtureServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var editAsphaltMixtureServiceModel = new EditAsphaltMixtureServiceModel();
            var asphaltMixtureType = "AMT 2";
            editAsphaltMixtureServiceModel.Type = asphaltMixtureType;
            editAsphaltMixtureServiceModel.Id = 1;
            var message = "Asphalt mixture's type already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltMixtureService.EditAsync(editAsphaltMixtureServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);
            var editAsphaltMixtureServiceModel = new EditAsphaltMixtureServiceModel();
            var asphaltMixtureType = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            editAsphaltMixtureServiceModel.Type = asphaltMixtureType;
            editAsphaltMixtureServiceModel.Id = 1;
            var message = "Asphalt mixture's type cannot be more than 30 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltMixtureService.EditAsync(editAsphaltMixtureServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistAsync_ShouldExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);

            Assert.True(await asphaltMixtureService.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistAsync_ShouldNotExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);

            Assert.False(await asphaltMixtureService.ExistsAsync(3));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);

            await asphaltMixtureService.GetByIdAsync(1);
            var expectedResult = "AMT 1";
            var actualResult = await asphaltMixtureService.GetByIdAsync(1);

            Assert.True(expectedResult == actualResult.Type);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltMixtureService = new AsphaltMixtureService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltMixtureService.GetByIdAsync(3);
            });
        }

        private List<AsphaltMixture> GetDummyData()
        {
            return new List<AsphaltMixture>()
            {
                new AsphaltMixture() { Type = "AMT 1" },
                new AsphaltMixture() { Type = "AMT 2" },
            };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.AddRange(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
