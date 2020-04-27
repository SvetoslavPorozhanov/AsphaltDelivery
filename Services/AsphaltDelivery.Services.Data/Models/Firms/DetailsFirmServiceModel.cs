namespace AsphaltDelivery.Services.Data.Models.Firms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class DetailsFirmServiceModel : IMapFrom<Firm>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> DriverFullNames { get; set; }

        public IEnumerable<string> TruckRegistrationNumbers { get; set; }

        public IEnumerable<int> CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Firm, DetailsFirmServiceModel>()
                .ForMember(
                    destination => destination.TruckRegistrationNumbers,
                    opts => opts.MapFrom(origin => origin.Trucks.Select(t => t.RegistrationNumber)))
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => origin.Courses.Select(c => c.Id)))
                .ForMember(
                    destination => destination.DriverFullNames,
                    opts => opts.MapFrom(origin => origin.Drivers.Select(d => d.FullName)));
        }
    }
}
