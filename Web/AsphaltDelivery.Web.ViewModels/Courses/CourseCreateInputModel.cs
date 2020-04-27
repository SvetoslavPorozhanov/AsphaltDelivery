namespace AsphaltDelivery.Web.ViewModels.Courses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class CourseCreateInputModel : IMapTo<CreateCourseServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string DateTime { get; set; }

        [Required]
        [Display(Name = "Driver Full Name")]
        public int DriverId { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }

        [Required]
        [Display(Name = "Truck Registration Number")]
        public int TruckId { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

        [Required]
        [Display(Name = "Firm Name")]
        public int FirmId { get; set; }

        public IEnumerable<Firm> Firms { get; set; }

        [Required]
        [Display(Name = "Asphalt Base Name")]
        public int AsphaltBaseId { get; set; }

        public IEnumerable<AsphaltBase> AsphaltBases { get; set; }

        [Required]
        [Display(Name = "Asphalt Mixture Type")]
        public int AsphaltMixtureId { get; set; }

        public IEnumerable<AsphaltMixture> AsphaltMixtures { get; set; }

        [Required]
        [Display(Name = "Road Object Name")]
        public int RoadObjectId { get; set; }

        public IEnumerable<RoadObject> RoadObjects { get; set; }

        // In t
        [Required]
        [Display(Name = "Weight in tons")]
        [Range(typeof(double), AttributesConstraints.MinCourseWeight, AttributesConstraints.MaxCourseWeight)]
        public double Weight { get; set; }

        // In km
        [Required]
        [Display(Name = "Transport Distance in km")]
        [Range(AttributesConstraints.MinCourseDistance, AttributesConstraints.MaxCourseDistance)]
        public int TransportDistance { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CourseCreateInputModel, CreateCourseServiceModel>()
                .ForMember(
                    destination => destination.DateTime,
                    opts => opts.MapFrom(origin => System.DateTime.ParseExact(origin.DateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)));
        }
    }
}
