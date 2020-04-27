namespace AsphaltDelivery.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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

    public class ResultsController : BaseController
    {
        private readonly ICourseService courseService;
        private readonly IDriverService driverService;
        private readonly ITruckService truckService;
        private readonly IFirmService firmService;
        private readonly IAsphaltBaseService asphaltBaseService;
        private readonly IAsphaltMixtureService asphaltMixtureService;
        private readonly IRoadObjectService roadObjectService;

        public ResultsController(
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
        public async Task<IActionResult> GetResult(CourseFilterInputModel courseFilterInputModel)
        {
            var filteredCourses = await this.courseService.All();

            if (string.IsNullOrWhiteSpace(courseFilterInputModel.FilterFromDateTime))
            {
                courseFilterInputModel.FilterFromDateTime = "Not applied.";
            }
            else
            {
                var filterFromDateTime = System.DateTime.ParseExact(courseFilterInputModel.FilterFromDateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                filteredCourses = filteredCourses.Where(c => c.DateTime.CompareTo(filterFromDateTime) >= 1).ToList();
            }

            if (string.IsNullOrWhiteSpace(courseFilterInputModel.FilterToDateTime))
            {
                courseFilterInputModel.FilterToDateTime = "Not applied.";
            }
            else
            {
                var filterToDateTime = System.DateTime.ParseExact(courseFilterInputModel.FilterToDateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                filteredCourses = filteredCourses.Where(c => c.DateTime.CompareTo(filterToDateTime) <= 1).ToList();
            }

            if (courseFilterInputModel.DriverIds == null)
            {
                courseFilterInputModel.DriverFullNames = "Not applied.";
            }
            else
            {
                courseFilterInputModel.DriverFullNames = string.Join(", ", this.driverService
                    .All()
                    .Where(d => courseFilterInputModel.DriverIds.Contains(d.Id))
                    .Select(d => d.FullName));

                filteredCourses = filteredCourses.Where(c => courseFilterInputModel.DriverIds.Contains(c.DriverId)).ToList();
            }

            if (courseFilterInputModel.TruckIds == null)
            {
                courseFilterInputModel.TruckRegistrationNumbers = "Not applied.";
            }
            else
            {
                courseFilterInputModel.TruckRegistrationNumbers = string.Join(", ", this.truckService
                    .All()
                    .Where(t => courseFilterInputModel.TruckIds.Contains(t.Id))
                    .Select(t => t.RegistrationNumber));

                filteredCourses = filteredCourses.Where(t => courseFilterInputModel.TruckIds.Contains(t.TruckId)).ToList();
            }

            if (courseFilterInputModel.FirmIds == null)
            {
                courseFilterInputModel.FirmNames = "Not applied.";
            }
            else
            {
                courseFilterInputModel.FirmNames = string.Join(", ", this.firmService
                    .All()
                    .Where(f => courseFilterInputModel.FirmIds.Contains(f.Id))
                    .Select(f => f.Name));

                filteredCourses = filteredCourses.Where(f => courseFilterInputModel.FirmIds.Contains(f.FirmId)).ToList();
            }

            if (courseFilterInputModel.AsphaltBaseIds == null)
            {
                courseFilterInputModel.AsphaltBaseNames = "Not applied.";
            }
            else
            {
                courseFilterInputModel.AsphaltBaseNames = string.Join(", ", this.asphaltBaseService
                    .All()
                    .Where(ab => courseFilterInputModel.AsphaltBaseIds.Contains(ab.Id))
                    .Select(ab => ab.Name));

                filteredCourses = filteredCourses.Where(ab => courseFilterInputModel.AsphaltBaseIds.Contains(ab.AsphaltBaseId)).ToList();
            }

            if (courseFilterInputModel.AsphaltMixtureIds == null)
            {
                courseFilterInputModel.AsphaltMixtureTypes = "Not applied.";
            }
            else
            {
                courseFilterInputModel.AsphaltMixtureTypes = string.Join(", ", this.asphaltMixtureService
                    .All()
                    .Where(am => courseFilterInputModel.AsphaltMixtureIds.Contains(am.Id))
                    .Select(am => am.Type));

                filteredCourses = filteredCourses.Where(am => courseFilterInputModel.AsphaltMixtureIds.Contains(am.AsphaltMixtureId)).ToList();
            }

            if (courseFilterInputModel.RoadObjectIds == null)
            {
                courseFilterInputModel.RoadObjectNames = "Not applied.";
            }
            else
            {
                courseFilterInputModel.RoadObjectNames = string.Join(", ", this.roadObjectService
                    .All()
                    .Where(ro => courseFilterInputModel.RoadObjectIds.Contains(ro.Id))
                    .Select(ro => ro.Name));

                filteredCourses = filteredCourses.Where(ro => courseFilterInputModel.RoadObjectIds.Contains(ro.RoadObjectId)).ToList();
            }

            courseFilterInputModel.FilteredCourses = new List<CoursesListingViewModel>();

            foreach (var filteredCourse in filteredCourses)
            {
                var filteredAllCourseServiceModel = AutoMapperConfig.MapperInstance.Map<AllCoursesServiceModel>(filteredCourse);
                var filteredCourseListingViewModel = AutoMapperConfig.MapperInstance.Map<CoursesListingViewModel>(filteredAllCourseServiceModel);
                courseFilterInputModel.FilteredCourses.Add(filteredCourseListingViewModel);
            }

            courseFilterInputModel.TotalWeightByDistance = filteredCourses.Sum(fc => fc.WeightByDistance).ToString("f3");

            return this.View(courseFilterInputModel);
        }
    }
}
