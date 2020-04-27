namespace AsphaltDelivery.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.AsphaltBases;
    using AsphaltDelivery.Services.Data.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Courses;
    using AsphaltDelivery.Services.Data.Drivers;
    using AsphaltDelivery.Services.Data.Firms;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Data.RoadObjects;
    using AsphaltDelivery.Services.Data.Tests.Common;
    using AsphaltDelivery.Services.Data.Trucks;
    using Xunit;

    public class CourseServiceTests
    {
        [Fact]
        public async Task All_ShouldReturnCorrectResultForAsphaltBases()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.AsphaltBase.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.AsphaltBase.Name).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForAsphaltMixtures()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.AsphaltMixture.Type).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.AsphaltMixture.Type).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForDateTimes()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.DateTime).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.DateTime).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForDrivers()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Driver.FullName).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Driver.FullName).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForFirms()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Firm.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Firm.Name).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForRoadObjects()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.RoadObject.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.RoadObject.Name).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForTransportDistance()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.TransportDistance).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.TransportDistance).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForTrucks()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Truck.RegistrationNumber).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Truck.RegistrationNumber).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForWeights()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Weight).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Weight).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnCorrectResultForWeightsByDistance()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.WeightByDistance).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.WeightByDistance).ToList();

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task All_ShouldReturnEmptyResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var courseService = new CourseService(context);

            var actualResult = await courseService.All();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForAsphaltBases()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.AsphaltBase.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.AsphaltBase.Name).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForAsphaltMixtures()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.AsphaltMixture.Type).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.AsphaltMixture.Type).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForDateTime()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.DateTime).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.DateTime).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForDrivers()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Driver.FullName).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Driver.FullName).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForFirms()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Firm.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Firm.Name).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForRoadObjects()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.RoadObject.Name).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.RoadObject.Name).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForTransportDistances()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.TransportDistance).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.TransportDistance).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForTrucks()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Truck.RegistrationNumber).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Truck.RegistrationNumber).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForWeights()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Weight).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.Weight).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public async Task AllToCoursesServiceModel_ShouldReturnCorrectResultForWeightsByDistance()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.WeightByDistance).ToList();
            var expectedResult = this.GetDummyData().Select(x => x.WeightByDistance).ToList();

            for (int i = 0; i < actualResultAsString.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }
        }

        [Fact]
        public void AllToCoursesServiceModel_ShouldReturnEmptyResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var courseService = new CourseService(context);

            var actualResult = courseService.AllToCoursesServiceModel();

            Assert.True(actualResult.Count() == 0);
        }

        [Fact]
        public async Task ArchivateAsync_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var archivateCourseServiceModel = new ArchivateCourseServiceModel();
            archivateCourseServiceModel.ArchivateFromYear = DateTime.ParseExact("2020", "yyyy", CultureInfo.InvariantCulture);
            archivateCourseServiceModel.ArchivateToYear = DateTime.ParseExact("2020", "yyyy", CultureInfo.InvariantCulture);
            await courseService.ArchivateAsync(archivateCourseServiceModel);
            var expectedResult = await courseService.All();

            Assert.True(expectedResult.Count() == 0);
        }

        [Fact]
        public async Task UnArchivateAsync_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var archivateCourseServiceModel = new ArchivateCourseServiceModel();
            archivateCourseServiceModel.ArchivateFromYear = DateTime.ParseExact("2020", "yyyy", CultureInfo.InvariantCulture);
            archivateCourseServiceModel.ArchivateToYear = DateTime.ParseExact("2020", "yyyy", CultureInfo.InvariantCulture);
            await courseService.ArchivateAsync(archivateCourseServiceModel);
            var unarchivateCourseServiceModel = new UnarchivateCourseServiceModel();
            unarchivateCourseServiceModel.UnarchivateFromYear = DateTime.ParseExact("2020", "yyyy", CultureInfo.InvariantCulture);
            unarchivateCourseServiceModel.UnarchivateToYear = DateTime.ParseExact("2020", "yyyy", CultureInfo.InvariantCulture);
            await courseService.UnarchivateAsync(unarchivateCourseServiceModel);
            var expectedResult = await courseService.All();

            Assert.True(expectedResult.Count() == 2);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            await courseService.CreateAsync(createCourseServiceModel);
            var actualResult = await courseService.All();
            var actualResultForAsphaltBase = actualResult.Where(x => x.Id == 3).Select(x => x.AsphaltBaseId).FirstOrDefault();
            var expectedResultForAsphaltBase = createCourseServiceModel.AsphaltBaseId;
            var actualResultForAsphaltMixture = actualResult.Where(x => x.Id == 3).Select(x => x.AsphaltMixtureId).FirstOrDefault();
            var expectedResultForAsphaltMixture = createCourseServiceModel.AsphaltMixtureId;
            var actualResultForDateTime = actualResult.Where(x => x.Id == 3).Select(x => x.DateTime).FirstOrDefault();
            var expectedResultForDateTime = createCourseServiceModel.DateTime;
            var actualResultForDriver = actualResult.Where(x => x.Id == 3).Select(x => x.DriverId).FirstOrDefault();
            var expectedResultForDriver = createCourseServiceModel.DriverId;
            var actualResultForFirm = actualResult.Where(x => x.Id == 3).Select(x => x.FirmId).FirstOrDefault();
            var expectedResultForFirm = createCourseServiceModel.FirmId;
            var actualResultForRoadObject = actualResult.Where(x => x.Id == 3).Select(x => x.RoadObjectId).FirstOrDefault();
            var expectedResultForRoadObject = createCourseServiceModel.RoadObjectId;
            var actualResultForTransportDistance = actualResult.Where(x => x.Id == 3).Select(x => x.TransportDistance).FirstOrDefault();
            var expectedResultForTransportDistance = createCourseServiceModel.TransportDistance;
            var actualResultForTruck = actualResult.Where(x => x.Id == 3).Select(x => x.TruckId).FirstOrDefault();
            var expectedResultForTruck = createCourseServiceModel.TruckId;
            var actualResultForWeight = actualResult.Where(x => x.Id == 3).Select(x => x.Weight).FirstOrDefault();
            var expectedResultForWeight = createCourseServiceModel.Weight;
            var actualResultForWeightByDistance = actualResult.Where(x => x.Id == 3).Select(x => x.WeightByDistance).FirstOrDefault();

            Assert.True(expectedResultForAsphaltBase == actualResultForAsphaltBase);
            Assert.True(expectedResultForAsphaltMixture == actualResultForAsphaltMixture);
            Assert.True(expectedResultForDateTime == actualResultForDateTime);
            Assert.True(expectedResultForDriver == actualResultForDriver);
            Assert.True(expectedResultForFirm == actualResultForFirm);
            Assert.True(expectedResultForRoadObject == actualResultForRoadObject);
            Assert.True(expectedResultForTransportDistance == actualResultForTransportDistance);
            Assert.True(expectedResultForTruck == actualResultForTruck);
            Assert.True(expectedResultForWeight == actualResultForWeight);
            Assert.True(actualResultForWeightByDistance == 150d);
            Assert.True(context.Firms.Where(f => f.Id == createCourseServiceModel.FirmId).Any(f => f.Drivers.Select(d => d.Id).Contains(createCourseServiceModel.DriverId)));
            Assert.True(context.Firms.Where(f => f.Id == createCourseServiceModel.FirmId).Any(f => f.Trucks.Select(t => t.Id).Contains(createCourseServiceModel.TruckId)));
            Assert.True(context.TruckDrivers.Any(td => td.TruckId == createCourseServiceModel.TruckId && td.DriverId == createCourseServiceModel.DriverId));
        }

        [Fact]
        public async Task CreateAsyncWithNonExistingDriver_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 4;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "One or more required properties are null.";

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            // Assert.Equal(message, exception.Message); ?
        }

        [Fact]
        public async Task CreateAsyncWithNonExistingAsphaltBase_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 3;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "One or more required properties are null.";

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsyncWithNonExistingAsphaltMixture_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 3;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "One or more required properties are null.";

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsyncWithNonExistingFirm_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 4;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "One or more required properties are null.";

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsyncWithNonExistingRoadObject_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 3;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "One or more required properties are null.";

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsyncWithNonExistingTruck_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 4;
            createCourseServiceModel.Weight = 15d;

            var message = "One or more required properties are null.";

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
        }

        [Fact]
        public async Task CreateAsyncWithExistingCourse_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "The combination of course's datetime and asphalt base properties must be unique.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithNegativOrZeroWeight_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = -3d;
            var message = "Course's weight must be between 0.001 and 30.000 tons.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithMoreThanMaxWeight_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 30.001d;
            var message = "Course's weight must be between 0.001 and 30.000 tons.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithNegativeOrZeroDistance_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = -1;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 20d;
            var message = "Course's distance must be between 1 and 50 km.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithMoreThanMaxDistance_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 51;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 20d;
            var message = "Course's distance must be between 1 and 50 km.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithInvalidDriverTruckCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 1;
            createCourseServiceModel.FirmId = 3;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 2;
            createCourseServiceModel.Weight = 15d;
            var message = "Driver and truck should be from the same firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithInvalidDriverTruckFirmCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 1;
            createCourseServiceModel.FirmId = 2;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 1;
            createCourseServiceModel.Weight = 15d;
            var message = "Driver and/or truck already have another firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithInvalidNewDriverTruckFirmCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 3;
            createCourseServiceModel.FirmId = 1;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 2;
            createCourseServiceModel.Weight = 15d;
            var message = "Driver and/or truck already have another firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task CreateAsyncWithInvalidDriverNewTruckFirmCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 2;
            createCourseServiceModel.FirmId = 1;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            var message = "Driver and/or truck already have another firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.CreateAsync(createCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task DeleteByIdAsyncWithOneCourse_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);

            var courseService = new CourseService(context);
            await courseService.DeleteByIdAsync(2);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Id).ToList();
            var expectedResult = new List<int> { 1 };

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }

            Assert.False(context.Firms.Where(f => f.Id == 2).Any(f => f.Drivers.Select(d => d.Id).Contains(2)));
            Assert.False(context.Firms.Where(f => f.Id == 2).Any(f => f.Trucks.Select(t => t.Id).Contains(2)));
            Assert.False(context.TruckDrivers.Any(td => td.TruckId == 2 && td.DriverId == 2));
        }

        [Fact]
        public async Task DeleteByIdAsyncWithMoreThanOneCourse_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 1;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 12:38", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 1;
            createCourseServiceModel.FirmId = 1;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 1;
            createCourseServiceModel.Weight = 15d;
            var courseService = new CourseService(context);
            await courseService.CreateAsync(createCourseServiceModel);
            await courseService.DeleteByIdAsync(3);

            var actualResult = await courseService.All();
            var actualResultAsString = actualResult.AsQueryable().Select(x => x.Id).ToList();
            var expectedResult = new List<int> { 1, 2 };

            for (int i = 0; i < actualResult.Count; i++)
            {
                Assert.True(expectedResult[i] == actualResultAsString[i]);
            }

            Assert.True(context.Firms.Where(f => f.Id == 1).Any(f => f.Drivers.Select(d => d.Id).Contains(1)));
            Assert.True(context.Firms.Where(f => f.Id == 1).Any(f => f.Trucks.Select(t => t.Id).Contains(1)));
            Assert.True(context.TruckDrivers.Any(td => td.TruckId == 1 && td.DriverId == 1));
        }

        [Fact]
        public async Task DeleteByIdAsyncWithInvalidId_ShouldArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.DeleteByIdAsync(3);
            });
        }

        [Fact]
        public async Task EditAsync_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var firmService = new FirmService(context);
            var truckService = new TruckService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);
            var createFirmServiceModel = new CreateFirmServiceModel();
            createFirmServiceModel.Name = "Firm3";
            await firmService.CreateAsync(createFirmServiceModel);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 3;
            editCourseServiceModel.FirmId = 3;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 3;
            editCourseServiceModel.Weight = 10d;
            await courseService.EditAsync(editCourseServiceModel);
            var actualResult = await courseService.All();
            var actualResultForAsphaltBase = actualResult.Where(x => x.Id == 2).Select(x => x.AsphaltBaseId).FirstOrDefault();
            var expectedResultForAsphaltBase = editCourseServiceModel.AsphaltBaseId;
            var actualResultForAsphaltMixture = actualResult.Where(x => x.Id == 2).Select(x => x.AsphaltMixtureId).FirstOrDefault();
            var expectedResultForAsphaltMixture = editCourseServiceModel.AsphaltMixtureId;
            var actualResultForDateTime = actualResult.Where(x => x.Id == 2).Select(x => x.DateTime).FirstOrDefault();
            var expectedResultForDateTime = editCourseServiceModel.DateTime;
            var actualResultForDriver = actualResult.Where(x => x.Id == 2).Select(x => x.DriverId).FirstOrDefault();
            var expectedResultForDriver = editCourseServiceModel.DriverId;
            var actualResultForFirm = actualResult.Where(x => x.Id == 2).Select(x => x.FirmId).FirstOrDefault();
            var expectedResultForFirm = editCourseServiceModel.FirmId;
            var actualResultForRoadObject = actualResult.Where(x => x.Id == 2).Select(x => x.RoadObjectId).FirstOrDefault();
            var expectedResultForRoadObject = editCourseServiceModel.RoadObjectId;
            var actualResultForTransportDistance = actualResult.Where(x => x.Id == 2).Select(x => x.TransportDistance).FirstOrDefault();
            var expectedResultForTransportDistance = editCourseServiceModel.TransportDistance;
            var actualResultForTruck = actualResult.Where(x => x.Id == 2).Select(x => x.TruckId).FirstOrDefault();
            var expectedResultForTruck = editCourseServiceModel.TruckId;
            var actualResultForWeight = actualResult.Where(x => x.Id == 2).Select(x => x.Weight).FirstOrDefault();
            var expectedResultForWeight = editCourseServiceModel.Weight;
            var actualResultForWeightByDistance = actualResult.Where(x => x.Id == 2).Select(x => x.WeightByDistance).FirstOrDefault();

            Assert.True(expectedResultForAsphaltBase == actualResultForAsphaltBase);
            Assert.True(expectedResultForAsphaltMixture == actualResultForAsphaltMixture);
            Assert.True(expectedResultForDateTime == actualResultForDateTime);
            Assert.True(expectedResultForDriver == actualResultForDriver);
            Assert.True(expectedResultForFirm == actualResultForFirm);
            Assert.True(expectedResultForRoadObject == actualResultForRoadObject);
            Assert.True(expectedResultForTransportDistance == actualResultForTransportDistance);
            Assert.True(expectedResultForTruck == actualResultForTruck);
            Assert.True(expectedResultForWeight == actualResultForWeight);
            Assert.True(actualResultForWeightByDistance == 200d);
            Assert.False(context.Firms.Where(f => f.Id == 2).Any(f => f.Drivers.Select(d => d.Id).Contains(2)));
            Assert.False(context.Firms.Where(f => f.Id == 2).Any(f => f.Trucks.Select(t => t.Id).Contains(2)));
            Assert.False(context.TruckDrivers.Any(td => td.TruckId == 2 && td.DriverId == 2));
            Assert.True(context.Firms.Where(f => f.Id == 3).Any(f => f.Drivers.Select(d => d.Id).Contains(3)));
            Assert.True(context.Firms.Where(f => f.Id == 3).Any(f => f.Trucks.Select(t => t.Id).Contains(3)));
            Assert.True(context.TruckDrivers.Any(td => td.TruckId == 3 && td.DriverId == 3));
        }

        [Fact]
        public async Task EditAsyncWithInvalidId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 0;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithNonExistingAsphaltBase_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 10;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithNonExistingAsphaltMixture_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 10;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithNonExistingDriver_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 10;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithNonExistingFirm_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 10;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithNonExistingRoadObject_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 10;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithNonExistingTruck_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 18:32", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 10;
            editCourseServiceModel.Weight = 10d;

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
        }

        [Fact]
        public async Task EditAsyncWithExistingCourse_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;
            var message = "The combination of course's datetime and asphalt base properties must be unique.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithExistingCourse_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 2;
            editCourseServiceModel.FirmId = 2;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 30;
            editCourseServiceModel.TruckId = 2;
            editCourseServiceModel.Weight = 10d;
            await courseService.EditAsync(editCourseServiceModel);
            var actualResult = await courseService.All();
            var actualResultForAsphaltBase = actualResult.Where(x => x.Id == 2).Select(x => x.AsphaltBaseId).FirstOrDefault();
            var expectedResultForAsphaltBase = editCourseServiceModel.AsphaltBaseId;
            var actualResultForAsphaltMixture = actualResult.Where(x => x.Id == 2).Select(x => x.AsphaltMixtureId).FirstOrDefault();
            var expectedResultForAsphaltMixture = editCourseServiceModel.AsphaltMixtureId;
            var actualResultForDateTime = actualResult.Where(x => x.Id == 2).Select(x => x.DateTime).FirstOrDefault();
            var expectedResultForDateTime = editCourseServiceModel.DateTime;
            var actualResultForDriver = actualResult.Where(x => x.Id == 2).Select(x => x.DriverId).FirstOrDefault();
            var expectedResultForDriver = editCourseServiceModel.DriverId;
            var actualResultForFirm = actualResult.Where(x => x.Id == 2).Select(x => x.FirmId).FirstOrDefault();
            var expectedResultForFirm = editCourseServiceModel.FirmId;
            var actualResultForRoadObject = actualResult.Where(x => x.Id == 2).Select(x => x.RoadObjectId).FirstOrDefault();
            var expectedResultForRoadObject = editCourseServiceModel.RoadObjectId;
            var actualResultForTransportDistance = actualResult.Where(x => x.Id == 2).Select(x => x.TransportDistance).FirstOrDefault();
            var expectedResultForTransportDistance = editCourseServiceModel.TransportDistance;
            var actualResultForTruck = actualResult.Where(x => x.Id == 2).Select(x => x.TruckId).FirstOrDefault();
            var expectedResultForTruck = editCourseServiceModel.TruckId;
            var actualResultForWeight = actualResult.Where(x => x.Id == 2).Select(x => x.Weight).FirstOrDefault();
            var expectedResultForWeight = editCourseServiceModel.Weight;
            var actualResultForWeightByDistance = actualResult.Where(x => x.Id == 2).Select(x => x.WeightByDistance).FirstOrDefault();

            Assert.True(expectedResultForAsphaltBase == actualResultForAsphaltBase);
            Assert.True(expectedResultForAsphaltMixture == actualResultForAsphaltMixture);
            Assert.True(expectedResultForDateTime == actualResultForDateTime);
            Assert.True(expectedResultForDriver == actualResultForDriver);
            Assert.True(expectedResultForFirm == actualResultForFirm);
            Assert.True(expectedResultForRoadObject == actualResultForRoadObject);
            Assert.True(expectedResultForTransportDistance == actualResultForTransportDistance);
            Assert.True(expectedResultForTruck == actualResultForTruck);
            Assert.True(expectedResultForWeight == actualResultForWeight);
            Assert.True(actualResultForWeightByDistance == 300d);
            Assert.True(context.Firms.Where(f => f.Id == 2).Any(f => f.Drivers.Select(d => d.Id).Contains(2)));
            Assert.True(context.Firms.Where(f => f.Id == 2).Any(f => f.Trucks.Select(t => t.Id).Contains(2)));
            Assert.True(context.TruckDrivers.Any(td => td.TruckId == 2 && td.DriverId == 2));
        }

        [Fact]
        public async Task EditAsyncWithExistingCourseAndChangedAsphaltBase_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 2;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 2;
            createCourseServiceModel.FirmId = 2;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 2;
            createCourseServiceModel.Weight = 15d;
            await courseService.CreateAsync(createCourseServiceModel);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 3;
            editCourseServiceModel.AsphaltBaseId = 1;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;
            var message = "The combination of course's datetime and asphalt base properties must be unique.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithExistingCourseAndChangedDateTime_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 2;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 2;
            createCourseServiceModel.FirmId = 2;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 2;
            createCourseServiceModel.Weight = 15d;
            await courseService.CreateAsync(createCourseServiceModel);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 3;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 10d;
            var message = "The combination of course's datetime and asphalt base properties must be unique.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithNegativeOrZeroWeight_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = -1d;
            var message = "Course's weight must be between 0.001 and 30.000 tons.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithMoreThanMaxWeight_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 20;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 30.001d;
            var message = "Course's weight must be between 0.001 and 30.000 tons.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithMoreThanMaxDistance_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 51;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 15d;
            var message = "Course's distance must be between 1 and 50 km.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithNegativeOrZeroDistance_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = -1;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 15d;
            var message = "Course's distance must be between 1 and 50 km.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithInvalidDriverTruckFirmCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 2;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 2;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 10;
            editCourseServiceModel.TruckId = 1;
            editCourseServiceModel.Weight = 15d;
            var message = "Driver and/or truck already have another firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithInvalidDriverTruckCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 2;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 2;
            createCourseServiceModel.FirmId = 2;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 2;
            createCourseServiceModel.Weight = 15d;
            await courseService.CreateAsync(createCourseServiceModel);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 3;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 20:03", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 1;
            editCourseServiceModel.FirmId = 2;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 10;
            editCourseServiceModel.TruckId = 2;
            editCourseServiceModel.Weight = 15d;
            var message = "Driver and truck should be from the same firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithInvalidNewDriverTruckFirmCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var driverService = new DriverService(context);
            var createDriverServiceModel = new CreateDriverServiceModel();
            createDriverServiceModel.FullName = "Driver3";
            await driverService.CreateAsync(createDriverServiceModel);

            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 2;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 2;
            createCourseServiceModel.FirmId = 2;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 2;
            createCourseServiceModel.Weight = 15d;
            await courseService.CreateAsync(createCourseServiceModel);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 3;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 20:03", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 3;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 10;
            editCourseServiceModel.TruckId = 2;
            editCourseServiceModel.Weight = 15d;
            var message = "Driver and/or truck already have another firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task EditAsyncWithInvalidDriverNewTruckFirmCombination_ShouldThrowInvalidOperationException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var truckService = new TruckService(context);
            var createTruckServiceModel = new CreateTruckServiceModel();
            createTruckServiceModel.RegistrationNumber = "RN3";
            await truckService.CreateAsync(createTruckServiceModel);

            var createCourseServiceModel = new CreateCourseServiceModel();
            createCourseServiceModel.AsphaltBaseId = 2;
            createCourseServiceModel.AsphaltMixtureId = 2;
            createCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModel.DriverId = 2;
            createCourseServiceModel.FirmId = 2;
            createCourseServiceModel.RoadObjectId = 2;
            createCourseServiceModel.TransportDistance = 10;
            createCourseServiceModel.TruckId = 3;
            createCourseServiceModel.Weight = 15d;
            await courseService.CreateAsync(createCourseServiceModel);

            var editCourseServiceModel = new EditCourseServiceModel();
            editCourseServiceModel.Id = 3;
            editCourseServiceModel.AsphaltBaseId = 2;
            editCourseServiceModel.AsphaltMixtureId = 1;
            editCourseServiceModel.DateTime = DateTime.ParseExact("02.04.2020 20:03", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            editCourseServiceModel.DriverId = 2;
            editCourseServiceModel.FirmId = 1;
            editCourseServiceModel.RoadObjectId = 1;
            editCourseServiceModel.TransportDistance = 10;
            editCourseServiceModel.TruckId = 3;
            editCourseServiceModel.Weight = 15d;
            var message = "Driver and/or truck already have another firm.";

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await courseService.EditAsync(editCourseServiceModel);
            });
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public async Task ExistsAsync_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var result = await courseService.ExistsAsync(2);

            Assert.True(result);
        }

        [Fact]
        public async Task ExistsAsyncWithInvalidId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var result = await courseService.ExistsAsync(0);

            Assert.False(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);
            var actualResult = await courseService.GetByIdAsync(1);
            var actualResultAsId = actualResult.Id;
            var expectedResult = 1;

            Assert.Equal(expectedResult, actualResultAsId);
        }

        [Fact]
        public async Task GetByIdAsyncWithNonExistingId_ShouldThrowArgumentNullException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedDataAsync2(context);
            var courseService = new CourseService(context);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await courseService.GetByIdAsync(0);
            });
        }

        private List<Course> GetDummyData()
        {
            var course1 = new Course();
            course1.AsphaltBase = new AsphaltBase() { Id = 1, Name = "ABN 1" };
            course1.AsphaltMixture = new AsphaltMixture() { Id = 1, Type = "AMT 1" };
            course1.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            course1.Driver = new Driver() { Id = 1, FullName = "DFN 1" };
            course1.Firm = new Firm() { Id = 1, Name = "FN 1" };
            course1.RoadObject = new RoadObject() { Id = 1, Name = "RON 1" };
            course1.TransportDistance = 30;
            course1.Truck = new Truck() { Id = 1, RegistrationNumber = "TRN 1" };
            course1.Weight = 20d;

            var course2 = new Course();
            course2.AsphaltBase = new AsphaltBase() { Id = 2, Name = "ABN 2" };
            course2.AsphaltMixture = new AsphaltMixture() { Id = 2, Type = "AMT 2" };
            course2.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            course2.Driver = new Driver() { Id = 2, FullName = "DFN 2" };
            course2.Firm = new Firm() { Id = 2, Name = "FN 2" };
            course2.RoadObject = new RoadObject() { Id = 2, Name = "RON 2" };
            course2.TransportDistance = 40;
            course2.Truck = new Truck() { Id = 2, RegistrationNumber = "TRN 2" };
            course2.Weight = 10d;

            var courseList = new List<Course>();
            courseList.Add(course1);
            courseList.Add(course2);

            return courseList;
        }

        private async Task SeedDataAsync(ApplicationDbContext context)
        {
            var asphaltBase1 = new AsphaltBase() { Id = 1, Name = "ABN 1" };
            var asphaltMixture1 = new AsphaltMixture() { Id = 1, Type = "AMT 1" };
            var driver1 = new Driver() { Id = 1, FullName = "DFN 1" };
            var firm1 = new Firm() { Id = 1, Name = "FN 1" };
            var roadObject1 = new RoadObject() { Id = 1, Name = "RON 1" };
            var truck1 = new Truck() { Id = 1, RegistrationNumber = "TRN 1" };

            var course1 = new Course();
            course1.AsphaltBase = asphaltBase1;
            course1.AsphaltMixture = asphaltMixture1;
            course1.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            course1.Driver = driver1;
            course1.Firm = firm1;
            course1.RoadObject = roadObject1;
            course1.TransportDistance = 30;
            course1.Truck = truck1;
            course1.Weight = 20d;

            var asphaltBase2 = new AsphaltBase() { Id = 2, Name = "ABN 2" };
            var asphaltMixture2 = new AsphaltMixture() { Id = 2, Type = "AMT 2" };
            var driver2 = new Driver() { Id = 2, FullName = "DFN 2" };
            var firm2 = new Firm() { Id = 2, Name = "FN 2" };
            var roadObject2 = new RoadObject() { Id = 2, Name = "RON 2" };
            var truck2 = new Truck() { Id = 2, RegistrationNumber = "TRN 2" };

            var course2 = new Course();
            course2.AsphaltBase = asphaltBase2;
            course2.AsphaltMixture = asphaltMixture2;
            course2.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            course2.Driver = driver2;
            course2.Firm = firm2;
            course2.RoadObject = roadObject2;
            course2.TransportDistance = 40;
            course2.Truck = truck2;
            course2.Weight = 10d;

            var courseList = new List<Course>();
            courseList.Add(course1);
            courseList.Add(course2);

            await context.AddRangeAsync(courseList);

            await context.SaveChangesAsync();
        }

        private async Task SeedDataAsync2(ApplicationDbContext context)
        {
            var asphaltBaseService = new AsphaltBaseService(context);
            var createAsphaltBaseServiceModelOne = new CreateAsphaltBaseServiceModel();
            createAsphaltBaseServiceModelOne.Name = "ABN 1";
            await asphaltBaseService.CreateAsync(createAsphaltBaseServiceModelOne);
            var createAsphaltBaseServiceModelTwo = new CreateAsphaltBaseServiceModel();
            createAsphaltBaseServiceModelTwo.Name = "ABN 2";
            await asphaltBaseService.CreateAsync(createAsphaltBaseServiceModelTwo);

            var asphaltMixtureService = new AsphaltMixtureService(context);
            var createAsphaltMixtureServiceModelOne = new CreateAsphaltMixtureServiceModel();
            createAsphaltMixtureServiceModelOne.Type = "AMT 1";
            await asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModelOne);
            var createAsphaltMixtureServiceModelTwo = new CreateAsphaltMixtureServiceModel();
            createAsphaltMixtureServiceModelTwo.Type = "AMT 2";
            await asphaltMixtureService.CreateAsync(createAsphaltMixtureServiceModelTwo);

            var driverService = new DriverService(context);
            var createDriverServiceModelOne = new CreateDriverServiceModel();
            createDriverServiceModelOne.FullName = "DFN 1";
            await driverService.CreateAsync(createDriverServiceModelOne);
            var createDriverServiceModelTwo = new CreateDriverServiceModel();
            createDriverServiceModelTwo.FullName = "DFN 2";
            await driverService.CreateAsync(createDriverServiceModelTwo);

            var firmService = new FirmService(context);
            var createFirmServiceModelOne = new CreateFirmServiceModel();
            createFirmServiceModelOne.Name = "FN 1";
            await firmService.CreateAsync(createFirmServiceModelOne);
            var createFirmServiceModelTwo = new CreateFirmServiceModel();
            createFirmServiceModelTwo.Name = "FN 2";
            await firmService.CreateAsync(createFirmServiceModelTwo);

            var roadObjectService = new RoadObjectService(context);
            var createRoadObjectServiceModelOne = new CreateRoadObjectServiceModel();
            createRoadObjectServiceModelOne.Name = "RON 1";
            await roadObjectService.CreateAsync(createRoadObjectServiceModelOne);
            var createRoadObjectServiceModelTwo = new CreateRoadObjectServiceModel();
            createRoadObjectServiceModelTwo.Name = "RON 2";
            await roadObjectService.CreateAsync(createRoadObjectServiceModelTwo);

            var truckService = new TruckService(context);
            var createTruckServiceModelOne = new CreateTruckServiceModel();
            createTruckServiceModelOne.RegistrationNumber = "TRN 1";
            await truckService.CreateAsync(createTruckServiceModelOne);
            var createTruckServiceModelTwo = new CreateTruckServiceModel();
            createTruckServiceModelTwo.RegistrationNumber = "TRN 2";
            await truckService.CreateAsync(createTruckServiceModelTwo);

            var courseService = new CourseService(context);

            var createCourseServiceModelOne = new CreateCourseServiceModel();
            createCourseServiceModelOne.AsphaltBaseId = 1;
            createCourseServiceModelOne.AsphaltMixtureId = 1;
            createCourseServiceModelOne.DateTime = DateTime.ParseExact("02.04.2020 09:48", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModelOne.DriverId = 1;
            createCourseServiceModelOne.FirmId = 1;
            createCourseServiceModelOne.RoadObjectId = 1;
            createCourseServiceModelOne.TransportDistance = 30;
            createCourseServiceModelOne.TruckId = 1;
            createCourseServiceModelOne.Weight = 20d;

            await courseService.CreateAsync(createCourseServiceModelOne);

            var createCourseServiceModelTwo = new CreateCourseServiceModel();
            createCourseServiceModelTwo.AsphaltBaseId = 2;
            createCourseServiceModelTwo.AsphaltMixtureId = 2;
            createCourseServiceModelTwo.DateTime = DateTime.ParseExact("02.04.2020 10:26", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            createCourseServiceModelTwo.DriverId = 2;
            createCourseServiceModelTwo.FirmId = 2;
            createCourseServiceModelTwo.RoadObjectId = 2;
            createCourseServiceModelTwo.TransportDistance = 40;
            createCourseServiceModelTwo.TruckId = 2;
            createCourseServiceModelTwo.Weight = 10d;

            await courseService.CreateAsync(createCourseServiceModelTwo);

            await context.SaveChangesAsync();
        }
    }
}
