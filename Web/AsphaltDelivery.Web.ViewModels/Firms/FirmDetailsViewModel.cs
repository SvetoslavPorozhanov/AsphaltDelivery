namespace AsphaltDelivery.Web.ViewModels.Firms
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class FirmDetailsViewModel : IMapFrom<DetailsFirmServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Truck Registration Numbers")]
        public string TruckRegistrationNumbers { get; set; }

        [Display(Name = "Driver Full Names")]
        public string DriverFullNames { get; set; }

        public string CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DetailsFirmServiceModel, FirmDetailsViewModel>()
                .ForMember(
                    destination => destination.TruckRegistrationNumbers,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.TruckRegistrationNumbers)))
                .ForMember(
                    destination => destination.DriverFullNames,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.DriverFullNames)))
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.CourseIds)));
        }
    }
}
