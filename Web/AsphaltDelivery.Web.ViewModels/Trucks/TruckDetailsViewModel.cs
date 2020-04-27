namespace AsphaltDelivery.Web.ViewModels.Trucks
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class TruckDetailsViewModel : IMapFrom<DetailsTruckServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Driver Full Names")]
        public string DriverFullNames { get; set; }

        [Display(Name = "Firm Name")]
        public string FirmName { get; set; }

        public string CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DetailsTruckServiceModel, TruckDetailsViewModel>()
                .ForMember(
                    destination => destination.DriverFullNames,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.DriverFullNames)))
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.CourseIds)));
        }
    }
}
