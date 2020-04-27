namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Data.RoadObjects;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using Xunit;

    public class RoadObjectServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);

            var actualResult = roadObjectService.All().Select(x => x.Name).ToList();
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
            var roadObjectService = new RoadObjectService(context);

            var actualResult = roadObjectService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyCreate()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var roadObjectService = new RoadObjectService(context);
            var createRoadObjectServiceModel = new CreateRoadObjectServiceModel();
            var roadObjectName = "RON 1";
            createRoadObjectServiceModel.Name = roadObjectName;

            await roadObjectService.CreateAsync(createRoadObjectServiceModel);
            var expectedResult = roadObjectName;
            var actualResult = roadObjectService
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
            var roadObjectService = new RoadObjectService(context);
            var createRoadObjectServiceModel = new CreateRoadObjectServiceModel();
            var roadObjectName = "  ";
            createRoadObjectServiceModel.Name = roadObjectName;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await roadObjectService.CreateAsync(createRoadObjectServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);
            var createRoadObjectServiceModel = new CreateRoadObjectServiceModel();
            var roadObjectName = "RON 1";
            createRoadObjectServiceModel.Name = roadObjectName;
            var message = "Road object's name already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await roadObjectService.CreateAsync(createRoadObjectServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var roadObjectService = new RoadObjectService(context);
            var createRoadObjectServiceModel = new CreateRoadObjectServiceModel();
            var roadObjectName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            createRoadObjectServiceModel.Name = roadObjectName;
            var message = "Road object's name cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await roadObjectService.CreateAsync(createRoadObjectServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldSuccessfullyDelete()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);
            var deleteRoadObjectServiceModel = new DeleteRoadObjectServiceModel();
            deleteRoadObjectServiceModel.Id = 1;

            await roadObjectService.DeleteByIdAsync(deleteRoadObjectServiceModel.Id);
            var expectedResult = 1;
            var actualResult = roadObjectService
                .All()
                .Count();
            var expectedResult2 = "RON 2";
            var actualResult2 = roadObjectService
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
            var roadObjectService = new RoadObjectService(context);
            var deleteRoadObjectServiceModel = new DeleteRoadObjectServiceModel();
            deleteRoadObjectServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await roadObjectService.DeleteByIdAsync(deleteRoadObjectServiceModel.Id);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldSuccessfullyEdit()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);
            var editRoadObjectServiceModel = new EditRoadObjectServiceModel();
            var roadObjectId = 1;
            var roadObjectName = "FN 3";
            editRoadObjectServiceModel.Id = roadObjectId;
            editRoadObjectServiceModel.Name = roadObjectName;

            await roadObjectService.EditAsync(editRoadObjectServiceModel);
            var expectedResult = roadObjectName;
            var actualResult = roadObjectService
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
            var roadObjectService = new RoadObjectService(context);
            var editRoadObjectServiceModel = new EditRoadObjectServiceModel();
            editRoadObjectServiceModel.Id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await roadObjectService.EditAsync(editRoadObjectServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithEmptyNameShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);
            var editRoadObjectServiceModel = new EditRoadObjectServiceModel();
            var roadObjectName = "  ";
            editRoadObjectServiceModel.Name = roadObjectName;
            editRoadObjectServiceModel.Id = 1;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await roadObjectService.EditAsync(editRoadObjectServiceModel);
            });
        }

        [Fact]
        public async Task EditAsync_WithExistingNameShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);
            var editRoadObjectServiceModel = new EditRoadObjectServiceModel();
            var roadObjectName = "RON 2";
            editRoadObjectServiceModel.Name = roadObjectName;
            editRoadObjectServiceModel.Id = 1;
            var message = "Road object's name already exists.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await roadObjectService.EditAsync(editRoadObjectServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsync_WithOverMaxNameLengthShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);
            var editRoadObjectServiceModel = new EditRoadObjectServiceModel();
            var roadObjectName = "qwertyuiop qwertyuiop qwertyuiop qwertyuiop qwertyuiop";
            editRoadObjectServiceModel.Name = roadObjectName;
            editRoadObjectServiceModel.Id = 1;
            var message = "Road object's name cannot be more than 50 characters.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await roadObjectService.EditAsync(editRoadObjectServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistAsync_ShouldExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);

            Assert.True(await roadObjectService.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistAsync_ShouldNotExist()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);

            Assert.False(await roadObjectService.ExistsAsync(3));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldSuccessfullyGet()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);

            await roadObjectService.GetByIdAsync(1);
            var expectedResult = "RON 1";
            var actualResult = await roadObjectService.GetByIdAsync(1);

            Assert.True(expectedResult == actualResult.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var roadObjectService = new RoadObjectService(context);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await roadObjectService.GetByIdAsync(3);
            });
        }

        private List<RoadObject> GetDummyData()
        {
            return new List<RoadObject>()
            {
                new RoadObject() { Name = "RON 1" },
                new RoadObject() { Name = "RON 2" },
            };
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            context.AddRange(this.GetDummyData());
            await context.SaveChangesAsync();
        }
    }
}
