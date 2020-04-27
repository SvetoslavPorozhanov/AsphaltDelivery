namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.AsphaltBases;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using Xunit;

    public class AsphaltBaseServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);

            var actualResult = asphaltBaseService.All().Select(x => x.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Name).ToList();

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
            var asphaltBaseService = new AsphaltBaseService(context);

            var actualResult = asphaltBaseService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyCreate()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltBaseService = new AsphaltBaseService(context);
            var createAsphaltBaseServiceModel = new CreateAsphaltBaseServiceModel();
            var asphaltBaseName = "ABN 1";
            createAsphaltBaseServiceModel.Name = asphaltBaseName;

            await asphaltBaseService.CreateAsync(createAsphaltBaseServiceModel);
            var expectedResult = asphaltBaseName;
            var actualResult = asphaltBaseService
                .All()
                .First()
                .Name;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task CreateAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltBaseService = new AsphaltBaseService(context);
            var createAsphaltBaseServiceModel = new CreateAsphaltBaseServiceModel();
            var asphaltBaseName = "  ";
            createAsphaltBaseServiceModel.Name = asphaltBaseName;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltBaseService.CreateAsync(createAsphaltBaseServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var createAsphaltBaseServiceModel = new CreateAsphaltBaseServiceModel();
            var asphaltBaseName = "ABN 1";
            createAsphaltBaseServiceModel.Name = asphaltBaseName;
            var message = "Asphalt base's name already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltBaseService.CreateAsync(createAsphaltBaseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var asphaltBaseService = new AsphaltBaseService(context);
            var createAsphaltBaseServiceModel = new CreateAsphaltBaseServiceModel();
            var asphaltBaseName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            createAsphaltBaseServiceModel.Name = asphaltBaseName;
            var message = "Asphalt base's name cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltBaseService.CreateAsync(createAsphaltBaseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldSuccessfullyDelete()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var deleteAsphaltBaseServiceModel = new DeleteAsphaltBaseServiceModel();
            deleteAsphaltBaseServiceModel.Id = 1;

            await asphaltBaseService.DeleteByIdAsync(deleteAsphaltBaseServiceModel.Id);
            var expectedResult = 1;
            var actualResult = asphaltBaseService
                .All()
                .Count();
            var expectedResult2 = "ABN 2";
            var actualResult2 = asphaltBaseService
                .All()
                .First()
                .Name;

            Assert.True(expectedResult == actualResult);
            Assert.True(expectedResult2 == actualResult2);
        }

        [Fact]
        public async Task DeleteByIdAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var deleteAsphaltBaseServiceModel = new DeleteAsphaltBaseServiceModel();
            deleteAsphaltBaseServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltBaseService.DeleteByIdAsync(deleteAsphaltBaseServiceModel.Id);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldSuccessfullyEdit()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var editAsphaltBaseServiceModel = new EditAsphaltBaseServiceModel();
            var asphaltBaseId = 1;
            var asphaltBaseName = "ABN 3";
            editAsphaltBaseServiceModel.Id = asphaltBaseId;
            editAsphaltBaseServiceModel.Name = asphaltBaseName;

            await asphaltBaseService.EditAsync(editAsphaltBaseServiceModel);
            var expectedResult = asphaltBaseName;
            var actualResult = asphaltBaseService
                .All()
                .First()
                .Name;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var editAsphaltBaseServiceModel = new EditAsphaltBaseServiceModel();
            editAsphaltBaseServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltBaseService.EditAsync(editAsphaltBaseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var editAsphaltBaseServiceModel = new EditAsphaltBaseServiceModel();
            var asphaltBaseName = "  ";
            editAsphaltBaseServiceModel.Name = asphaltBaseName;
            editAsphaltBaseServiceModel.Id = 1;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltBaseService.EditAsync(editAsphaltBaseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var editAsphaltBaseServiceModel = new EditAsphaltBaseServiceModel();
            var asphaltBaseName = "ABN 2";
            editAsphaltBaseServiceModel.Name = asphaltBaseName;
            editAsphaltBaseServiceModel.Id = 1;
            var message = "Asphalt base's name already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltBaseService.EditAsync(editAsphaltBaseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);
            var editAsphaltBaseServiceModel = new EditAsphaltBaseServiceModel();
            var asphaltBaseName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            editAsphaltBaseServiceModel.Name = asphaltBaseName;
            editAsphaltBaseServiceModel.Id = 1;
            var message = "Asphalt base's name cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await asphaltBaseService.EditAsync(editAsphaltBaseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistAsync_ShouldExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);

            Assert.True(await asphaltBaseService.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistAsync_ShouldNotExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);

            Assert.False(await asphaltBaseService.ExistsAsync(3));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);

            await asphaltBaseService.GetByIdAsync(1);
            var expectedResult = "ABN 1";
            var actualResult = await asphaltBaseService.GetByIdAsync(1);

            Assert.True(expectedResult == actualResult.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var asphaltBaseService = new AsphaltBaseService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await asphaltBaseService.GetByIdAsync(3);
            });
        }

        private List<AsphaltBase> GetDummyData()
        {
            return new List<AsphaltBase>()
            {
                new AsphaltBase() { Name = "ABN 1" },
                new AsphaltBase() { Name = "ABN 2" },
            };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.AddRange(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
