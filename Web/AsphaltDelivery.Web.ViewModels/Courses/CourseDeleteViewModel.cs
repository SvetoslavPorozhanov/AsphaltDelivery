namespace AsphaltDelivery.Web.ViewModels.Courses
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class CourseDeleteViewModel : IMapFrom<DeleteCourseServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string DateTime { get; set; }

        [Display(Name = "Driver Full Name")]
        public string DriverFullName { get; set; }

        [Display(Name = "Truck Registration Number")]
        public string TruckRegistrationNumber { get; set; }

        [Display(Name = "Firm Name")]
        public string FirmName { get; set; }

        [Display(Name = "Asphalt Base Name")]
        public string AsphaltBaseName { get; set; }

        [Display(Name = "Asphalt Mixture Type")]
        public string AsphaltMixtureType { get; set; }

        [Display(Name = "Road Object Name")]
        public string RoadObjectName { get; set; }

        public string Weight { get; set; }

        [Display(Name = "Transport Distance")]
        public string TransportDistance { get; set; }

        [Display(Name = "Weight By Distance")]
        public string WeightByDistance { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DeleteCourseServiceModel, CourseDeleteViewModel>()
                .ForMember(
                    destination => destination.DateTime,
                    opts => opts.MapFrom(origin => origin.DateTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(
                    destination => destination.Weight,
                    opts => opts.MapFrom(origin => origin.Weight.ToString("f3")))
                .ForMember(
                    destination => destination.TransportDistance,
                    opts => opts.MapFrom(origin => origin.TransportDistance.ToString("f0")))
                .ForMember(
                    destination => destination.WeightByDistance,
                    opts => opts.MapFrom(origin => origin.WeightByDistance.ToString("f3")));
        }
    }
}
