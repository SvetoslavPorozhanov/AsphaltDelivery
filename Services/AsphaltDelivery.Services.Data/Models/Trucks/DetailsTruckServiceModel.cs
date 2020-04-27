namespace AsphaltDelivery.Services.Data.Models.Trucks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class DetailsTruckServiceModel : IMapFrom<Truck>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public IEnumerable<string> DriverFullNames { get; set; }

        public string FirmName { get; set; }

        public IEnumerable<int> CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Truck, DetailsTruckServiceModel>()
                .ForMember(
                    destination => destination.DriverFullNames,
                    opts => opts.MapFrom(origin => origin.TruckDrivers.Select(td => td.Driver.FullName)))
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => origin.Courses.Select(c => c.Id)))
                .ForMember(
                    destination => destination.FirmName,
                    opts => opts.MapFrom(origin => origin.Firm.Name));
        }
    }
}
