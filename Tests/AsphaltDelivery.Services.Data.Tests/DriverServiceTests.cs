namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Drivers;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using Xunit;

    public class DriverServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);

            var actualResult = driverService.All().Select(x => x.FullName).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.FullName).ToList();

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
            var driverService = new DriverService(context);

            var actualResult = driverService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyCreate()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var driverService = new DriverService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            var driverFullName = "DFN 1";
            createDriverServiceModel.FullName = driverFullName;

            await driverService.CreateAsync(createDriverServiceModel);
            var expectedResult = driverFullName;
            var actualResult = driverService
                .All()
                .First()
                .FullName;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task CreateAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var driverService = new DriverService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            var driverFullName = "  ";
            createDriverServiceModel.FullName = driverFullName;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await driverService.CreateAsync(createDriverServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            var driverFullName = "DFN 1";
            createDriverServiceModel.FullName = driverFullName;
            var message = "Driver's fullname already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await driverService.CreateAsync(createDriverServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var driverService = new DriverService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            var driverFullName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            createDriverServiceModel.FullName = driverFullName;
            var message = "Driver's fullname cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await driverService.CreateAsync(createDriverServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldSuccessfullyDelete()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var deleteDriverServiceModel = new DeleteDriverServiceModel();
            deleteDriverServiceModel.Id = 1;

            await driverService.DeleteByIdAsync(deleteDriverServiceModel.Id);
            var expectedResult = 1;
            var actualResult = driverService
                .All()
                .Count();
            var expectedResult2 = "DFN 2";
            var actualResult2 = driverService
                .All()
                .First()
                .FullName;

            Assert.True(expectedResult == actualResult);
            Assert.True(expectedResult2 == actualResult2);
        }

        [Fact]
        public async Task DeleteByIdAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var deleteDriverServiceModel = new DeleteDriverServiceModel();
            deleteDriverServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await driverService.DeleteByIdAsync(deleteDriverServiceModel.Id);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldSuccessfullyEdit()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var editDriverServiceModel = new EditDriverServiceModel();
            var driverId = 1;
            var driverFullName = "DFN 3";
            editDriverServiceModel.Id = driverId;
            editDriverServiceModel.FullName = driverFullName;

            await driverService.EditAsync(editDriverServiceModel);
            var expectedResult = driverFullName;
            var actualResult = driverService
                .All()
                .First()
                .FullName;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var editDriverServiceModel = new EditDriverServiceModel();
            editDriverServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await driverService.EditAsync(editDriverServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var editDriverServiceModel = new EditDriverServiceModel();
            var driverFullName = "  ";
            editDriverServiceModel.FullName = driverFullName;
            editDriverServiceModel.Id = 1;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await driverService.EditAsync(editDriverServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var editDriverServiceModel = new EditDriverServiceModel();
            var driverFullName = "DFN 2";
            editDriverServiceModel.FullName = driverFullName;
            editDriverServiceModel.Id = 1;
            var message = "Driver's fullname already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await driverService.EditAsync(editDriverServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);
            var editDriverServiceModel = new EditDriverServiceModel();
            var driverFullName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            editDriverServiceModel.FullName = driverFullName;
            editDriverServiceModel.Id = 1;
            var message = "Driver's fullname cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await driverService.EditAsync(editDriverServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistAsync_ShouldExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);

            Assert.True(await driverService.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistAsync_ShouldNotExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);

            Assert.False(await driverService.ExistsAsync(3));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);

            await driverService.GetByIdAsync(1);
            var expectedResult = "DFN 1";
            var actualResult = await driverService.GetByIdAsync(1);

            Assert.True(expectedResult == actualResult.FullName);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var driverService = new DriverService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await driverService.GetByIdAsync(3);
            });
        }

        private List<Driver> GetDummyData()
        {
            return new List<Driver>()
            {
                new Driver() { FullName = "DFN 1" },
                new Driver() { FullName = "DFN 2" },
            };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.AddRange(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
