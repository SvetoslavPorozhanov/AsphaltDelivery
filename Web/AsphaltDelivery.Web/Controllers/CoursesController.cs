namespace AsphaltDelivery.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class CoursesController : BaseController
    {
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

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var courses = this.courseService.AllToCoursesServiceModel().AsQueryable().To<CoursesListingViewModel>();

            return this.View(courses);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = await this.courseService.GetByIdAsync(id);

            if (course == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var detailsCourseServiceModel = AutoMapperConfig.MapperInstance.Map<DetailsCourseServiceModel>(course);
            var courseDetailsViewModel = AutoMapperConfig.MapperInstance.Map<CourseDetailsViewModel>(detailsCourseServiceModel);

            return this.View(courseDetailsViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Filter()
        {
            var courseFilterInputModel = new CourseFilterInputModel
            {
                Drivers = this.driverService.All().ToArray(),
                Trucks = this.truckService.All().ToArray(),
                Firms = this.firmService.All().ToArray(),
                AsphaltBases = this.asphaltBaseService.All().ToArray(),
                AsphaltMixtures = this.asphaltMixtureService.All().ToArray(),
                RoadObjects = this.roadObjectService.All().ToArray(),
            };

            return this.View(courseFilterInputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Filter(CourseFilterInputModel courseFilterInputModel)
        {
            return this.RedirectToAction("GetResult", "Results", courseFilterInputModel);
        }
    }
}
