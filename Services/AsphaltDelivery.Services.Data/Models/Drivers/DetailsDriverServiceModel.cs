namespace AsphaltDelivery.Services.Data.Models.Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class DetailsDriverServiceModel : IMapFrom<Driver>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public IEnumerable<string> TruckRegistrationNumbers { get; set; }

        public string FirmName { get; set; }

        public IEnumerable<int> CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Driver, DetailsDriverServiceModel>()
                .ForMember(
                    destination => destination.TruckRegistrationNumbers,
                    opts => opts.MapFrom(origin => origin.DriverTrucks.Select(dt => dt.Truck.RegistrationNumber)))
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => origin.Courses.Select(c => c.Id)))
                .ForMember(
                    destination => destination.FirmName,
                    opts => opts.MapFrom(origin => origin.Firm.Name));
        }
    }
}
