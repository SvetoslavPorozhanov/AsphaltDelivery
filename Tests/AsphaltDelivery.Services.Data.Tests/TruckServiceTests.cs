namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using AsphaltDelivery.Services.Data.Trucks;
    using Xunit;

    public class TruckServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);

            var actualResult = truckService.All().Select(x => x.RegistrationNumber).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.RegistrationNumber).ToList();

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
            var truckService = new TruckService(context);

            var actualResult = truckService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyCreate()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var truckService = new TruckService(context);
            var createTruckServiceModel = new CreateTruckServiceModel();
            var truckRegistrationNumber = "TRN 1";
            createTruckServiceModel.RegistrationNumber = truckRegistrationNumber;

            await truckService.CreateAsync(createTruckServiceModel);
            var expectedResult = truckRegistrationNumber;
            var actualResult = truckService
                .All()
                .First()
                .RegistrationNumber;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task CreateAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var truckService = new TruckService(context);
            var createTruckServiceModel = new CreateTruckServiceModel();
            var truckRegistrationNumber = "  ";
            createTruckServiceModel.RegistrationNumber = truckRegistrationNumber;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await truckService.CreateAsync(createTruckServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var createTruckServiceModel = new CreateTruckServiceModel();
            var truckRegistrationNumber = "TRN 1";
            createTruckServiceModel.RegistrationNumber = truckRegistrationNumber;
            var message = "Truck's Registration number already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await truckService.CreateAsync(createTruckServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var truckService = new TruckService(context);
            var createTruckServiceModel = new CreateTruckServiceModel();
            var truckRegistrationNumber = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            createTruckServiceModel.RegistrationNumber = truckRegistrationNumber;
            var message = "Truck's Registration number cannot be more than 8 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await truckService.CreateAsync(createTruckServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldSuccessfullyDelete()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var deleteTruckServiceModel = new DeleteTruckServiceModel();
            deleteTruckServiceModel.Id = 1;

            await truckService.DeleteByIdAsync(deleteTruckServiceModel.Id);
            var expectedResult = 1;
            var actualResult = truckService
                .All()
                .Count();
            var expectedResult2 = "TRN 2";
            var actualResult2 = truckService
                .All()
                .First()
                .RegistrationNumber;

            Assert.True(expectedResult == actualResult);
            Assert.True(expectedResult2 == actualResult2);
        }

        [Fact]
        public async Task DeleteByIdAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var deleteTruckServiceModel = new DeleteTruckServiceModel();
            deleteTruckServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await truckService.DeleteByIdAsync(deleteTruckServiceModel.Id);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldSuccessfullyEdit()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var editTruckServiceModel = new EditTruckServiceModel();
            var truckId = 1;
            var truckRegistrationNumber = "FN 3";
            editTruckServiceModel.Id = truckId;
            editTruckServiceModel.RegistrationNumber = truckRegistrationNumber;

            await truckService.EditAsync(editTruckServiceModel);
            var expectedResult = truckRegistrationNumber;
            var actualResult = truckService
                .All()
                .First()
                .RegistrationNumber;

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_WithNonExistingIdShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var editTruckServiceModel = new EditTruckServiceModel();
            editTruckServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await truckService.EditAsync(editTruckServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var editTruckServiceModel = new EditTruckServiceModel();
            var truckRegistrationNumber = "  ";
            editTruckServiceModel.RegistrationNumber = truckRegistrationNumber;
            editTruckServiceModel.Id = 1;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await truckService.EditAsync(editTruckServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var editTruckServiceModel = new EditTruckServiceModel();
            var truckregistrationNumber = "TRN 2";
            editTruckServiceModel.RegistrationNumber = truckregistrationNumber;
            editTruckServiceModel.Id = 1;
            var message = "Truck's Registration number already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await truckService.EditAsync(editTruckServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);
            var editTruckServiceModel = new EditTruckServiceModel();
            var truckRegistrationNumber = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            editTruckServiceModel.RegistrationNumber = truckRegistrationNumber;
            editTruckServiceModel.Id = 1;
            var message = "Truck's Registration number cannot be more than 8 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await truckService.EditAsync(editTruckServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistAsync_ShouldExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);

            Assert.True(await truckService.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistAsync_ShouldNotExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);

            Assert.False(await truckService.ExistsAsync(3));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);

            await truckService.GetByIdAsync(1);
            var expectedResult = "TRN 1";
            var actualResult = await truckService.GetByIdAsync(1);

            Assert.True(expectedResult == actualResult.RegistrationNumber);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var truckService = new TruckService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await truckService.GetByIdAsync(3);
            });
        }

        private List<Truck> GetDummyData()
        {
            return new List<Truck>()
            {
                new Truck() { RegistrationNumber = "TRN 1" },
                new Truck() { RegistrationNumber = "TRN 2" },
            };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.AddRange(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
