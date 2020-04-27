namespace AsphaltDelivery.Web.Areas.Administration.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    
    using AsphaltDelivery.Services.Data.AsphaltBases;
    using AsphaltDelivery.Services.Data.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Courses;
    using AsphaltDelivery.Services.Data.Drivers;
    using AsphaltDelivery.Services.Data.Firms;
    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Data.RoadObjects;
    using AsphaltDelivery.Services.Data.Trucks;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Web.ViewModels.Courses;
    using Microsoft.AspNetCore.Mvc;

    public class CoursesController : AdministrationController
    {
        private const string InvalidDateTimeFormatErrorMessage = "The provided string is not in the correct datetime format!";
        private readonly ICourseService courseService;
        private readonly IDriverService driverService;
        private readonly ITruckService truckService;
        private readonly IFirmService firmService;
        private readonly IAsphaltBaseService asphaltBaseService;
        private readonly IAsphaltMixtureService asphaltMixtureService;
        private readonly IRoadObjectService roadObjectService;

        public CoursesController(
            ICourseService courseService,
            IDriverService driverService,
            ITruckService truckService,
            IFirmService firmService,
            IAsphaltBaseService asphaltBaseService,
            IAsphaltMixtureService asphaltMixtureService,
            IRoadObjectService roadObjectService)
        {
            this.courseService = courseService;
            this.driverService = driverService;
            this.truckService = truckService;
            this.firmService = firmService;
            this.asphaltBaseService = asphaltBaseService;
            this.asphaltMixtureService = asphaltMixtureService;
            this.roadObjectService = roadObjectService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var courseCreateInputModel = new CourseCreateInputModel
            {
                Drivers = this.driverService.All().ToArray(),
                Trucks = this.truckService.All().ToArray(),
                Firms = this.firmService.All().ToArray(),
                AsphaltBases = this.asphaltBaseService.All().ToArray(),
                AsphaltMixtures = this.asphaltMixtureService.All().ToArray(),
                RoadObjects = this.roadObjectService.All().ToArray(),
            };

            return this.View(courseCreateInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateInputModel courseCreateInputModel)
        {
            if (!DateTime.TryParseExact(courseCreateInputModel.DateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                throw new InvalidOperationException(InvalidDateTimeFormatErrorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(courseCreateInputModel);
            }

            var createCourseServiceModel = AutoMapperConfig.MapperInstance.Map<CreateCourseServiceModel>(courseCreateInputModel);

            await this.courseService.CreateAsync(createCourseServiceModel);

            return this.Redirect($"/Courses/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await this.courseService.GetByIdAsync(id);

            if (course == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editCourseServiceModel = AutoMapperConfig.MapperInstance.Map<EditCourseServiceModel>(course);
            var courseEditInputModel = AutoMapperConfig.MapperInstance.Map<CourseEditInputModel>(editCourseServiceModel);

            // Extract Method?
            var driver = await this.driverService.GetByIdAsync(course.DriverId);
            var driverList = this.driverService.All().ToList();
            driverList.Remove(driver);
            driverList.Insert(0, driver);
            courseEditInputModel.Drivers = driverList;

            var truck = await this.truckService.GetByIdAsync(course.TruckId);
            var truckList = this.truckService.All().ToList();
            truckList.Remove(truck);
            truckList.Insert(0, truck);
            courseEditInputModel.Trucks = truckList;

            var firm = await this.firmService.GetByIdAsync(course.FirmId);
            var firmList = this.firmService.All().ToList();
            firmList.Remove(firm);
            firmList.Insert(0, firm);
            courseEditInputModel.Firms = firmList;

            var asphaltBase = await this.asphaltBaseService.GetByIdAsync(course.AsphaltBaseId);
            var asphaltBaseList = this.asphaltBaseService.All().ToList();
            asphaltBaseList.Remove(asphaltBase);
            asphaltBaseList.Insert(0, asphaltBase);
            courseEditInputModel.AsphaltBases = asphaltBaseList;

            var asphaltMixture = await this.asphaltMixtureService.GetByIdAsync(course.AsphaltMixtureId);
            var asphaltMixtureList = this.asphaltMixtureService.All().ToList();
            asphaltMixtureList.Remove(asphaltMixture);
            asphaltMixtureList.Insert(0, asphaltMixture);
            courseEditInputModel.AsphaltMixtures = asphaltMixtureList;

            var roadObject = await this.roadObjectService.GetByIdAsync(course.RoadObjectId);
            var roadObjectList = this.roadObjectService.All().ToList();
            roadObjectList.Remove(roadObject);
            roadObjectList.Insert(0, roadObject);
            courseEditInputModel.RoadObjects = roadObjectList;

            return this.View(courseEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseEditInputModel courseEditInputModel)
        {
            if (!DateTime.TryParseExact(courseEditInputModel.DateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                throw new InvalidOperationException(InvalidDateTimeFormatErrorMessage);
            }

            if (await this.courseService.ExistsAsync(courseEditInputModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(courseEditInputModel);
            }

            var editCourseServiceModel = AutoMapperConfig.MapperInstance.Map<EditCourseServiceModel>(courseEditInputModel);

            await this.courseService.EditAsync(editCourseServiceModel);

            return this.Redirect($"/Courses/Details/{editCourseServiceModel.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await this.courseService.GetByIdAsync(id);
            var deleteCourseServiceModel = AutoMapperConfig.MapperInstance.Map<DeleteCourseServiceModel>(course);
            var courseDeleteViewModel = AutoMapperConfig.MapperInstance.Map<CourseDeleteViewModel>(deleteCourseServiceModel);

            return this.View(courseDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourseDeleteViewModel courseDeleteViewModel)
        {
            if (await this.courseService.ExistsAsync(courseDeleteViewModel.Id) == false)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.courseService.DeleteByIdAsync(courseDeleteViewModel.Id);

            return this.Redirect($"/Courses/All");
        }

        [HttpGet]
        public IActionResult Archivate()
        {
            var courseArchivateInputModel = new CourseArchivateInputModel();

            return this.View(courseArchivateInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Archivate(CourseArchivateInputModel courseArchivateInputModel)
        {
            if (!DateTime.TryParseExact(courseArchivateInputModel.ArchivateFromYear, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultFrom) ||
                !DateTime.TryParseExact(courseArchivateInputModel.ArchivateToYear, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultTo))
            {
                throw new InvalidOperationException(InvalidDateTimeFormatErrorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(courseArchivateInputModel);
            }

            var archivateCourseServiceModel = AutoMapperConfig.MapperInstance.Map<ArchivateCourseServiceModel>(courseArchivateInputModel);

            await this.courseService.ArchivateAsync(archivateCourseServiceModel);

            return this.Redirect($"/Courses/All");
        }

        [HttpGet]
        public IActionResult Unarchivate()
        {
            var courseUnarchivateInputModel = new CourseUnarchivateInputModel();

            return this.View(courseUnarchivateInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Unarchivate(CourseUnarchivateInputModel courseUnarchivateInputModel)
        {
            if (!DateTime.TryParseExact(courseUnarchivateInputModel.UnarchivateFromYear, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultFrom) ||
                !DateTime.TryParseExact(courseUnarchivateInputModel.UnarchivateToYear, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultTo))
            {
                throw new InvalidOperationException(InvalidDateTimeFormatErrorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(courseUnarchivateInputModel);
            }

            var unarchivateCourseServiceModel = AutoMapperConfig.MapperInstance.Map<UnarchivateCourseServiceModel>(courseUnarchivateInputModel);

            await this.courseService.UnarchivateAsync(unarchivateCourseServiceModel);

            return this.Redirect($"/Courses/All");
        }
    }
}
