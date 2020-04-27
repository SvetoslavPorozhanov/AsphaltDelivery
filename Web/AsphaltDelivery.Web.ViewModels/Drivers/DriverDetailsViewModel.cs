namespace AsphaltDelivery.Web.ViewModels.Drivers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class DriverDetailsViewModel : IMapFrom<DetailsDriverServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Truck Registration Numbers")]
        public string TruckRegistrationNumbers { get; set; }

        [Display(Name = "Firm Name")]
        public string FirmName { get; set; }

        public string CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DetailsDriverServiceModel, DriverDetailsViewModel>()
                .ForMember(
                    destination => destination.TruckRegistrationNumbers,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.TruckRegistrationNumbers)))
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.CourseIds)));
        }
    }
}
