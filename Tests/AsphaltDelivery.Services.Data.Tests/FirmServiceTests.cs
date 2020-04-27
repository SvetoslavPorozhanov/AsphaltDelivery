namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Firms;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using Xunit;

    public class FirmServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);

            var actualResult = firmService.All().Select(x => x.Name).ToList();
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
            var firmService = new FirmService(context);

            var actualResult = firmService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyCreate()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var firmService = new FirmService(context);
            var createFirmServiceModel = new CreateFirmServiceModel();
            var firmName = "FN 1";
            createFirmServiceModel.Name = firmName;

            await firmService.CreateAsync(createFirmServiceModel);
            var expectedResult = firmName;
            var actualResult = firmService
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
            var firmService = new FirmService(context);
            var createFirmServiceModel = new CreateFirmServiceModel();
            var firmName = "  ";
            createFirmServiceModel.Name = firmName;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await firmService.CreateAsync(createFirmServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);
            var createFirmServiceModel = new CreateFirmServiceModel();
            var firmName = "FN 1";
            createFirmServiceModel.Name = firmName;
            var message = "Firm's name already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await firmService.CreateAsync(createFirmServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var firmService = new FirmService(context);
            var createFirmServiceModel = new CreateFirmServiceModel();
            var firmName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            createFirmServiceModel.Name = firmName;
            var message = "Firm's Name cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await firmService.CreateAsync(createFirmServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldSuccessfullyDelete()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);
            var deleteFirmServiceModel = new DeleteFirmServiceModel();
            deleteFirmServiceModel.Id = 1;

            await firmService.DeleteByIdAsync(deleteFirmServiceModel.Id);
            var expectedResult = 1;
            var actualResult = firmService
                .All()
                .Count();
            var expectedResult2 = "FN 2";
            var actualResult2 = firmService
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
            var firmService = new FirmService(context);
            var deleteFirmServiceModel = new DeleteFirmServiceModel();
            deleteFirmServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await firmService.DeleteByIdAsync(deleteFirmServiceModel.Id);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldSuccessfullyEdit()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);
            var editFirmServiceModel = new EditFirmServiceModel();
            var firmId = 1;
            var firmName = "FN 3";
            editFirmServiceModel.Id = firmId;
            editFirmServiceModel.Name = firmName;

            await firmService.EditAsync(editFirmServiceModel);
            var expectedResult = firmName;
            var actualResult = firmService
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
            var firmService = new FirmService(context);
            var editFirmServiceModel = new EditFirmServiceModel();
            editFirmServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await firmService.EditAsync(editFirmServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);
            var editFirmServiceModel = new EditFirmServiceModel();
            var firmName = "  ";
            editFirmServiceModel.Name = firmName;
            editFirmServiceModel.Id = 1;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await firmService.EditAsync(editFirmServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);
            var editFirmServiceModel = new EditFirmServiceModel();
            var firmName = "FN 2";
            editFirmServiceModel.Name = firmName;
            editFirmServiceModel.Id = 1;
            var message = "Firm's name already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await firmService.EditAsync(editFirmServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);
            var editFirmServiceModel = new EditFirmServiceModel();
            var firmName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            editFirmServiceModel.Name = firmName;
            editFirmServiceModel.Id = 1;
            var message = "Firm's Name cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await firmService.EditAsync(editFirmServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistAsync_ShouldExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);

            Assert.True(await firmService.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistAsync_ShouldNotExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);

            Assert.False(await firmService.ExistsAsync(3));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);

            await firmService.GetByIdAsync(1);
            var expectedResult = "FN 1";
            var actualResult = await firmService.GetByIdAsync(1);

            Assert.True(expectedResult == actualResult.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var firmService = new FirmService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await firmService.GetByIdAsync(3);
            });
        }

        private List<Firm> GetDummyData()
        {
            return new List<Firm>()
            {
                new Firm() { Name = "FN 1" },
                new Firm() { Name = "FN 2" },
            };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.AddRange(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
