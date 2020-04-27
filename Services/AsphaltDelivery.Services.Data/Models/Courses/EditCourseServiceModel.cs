namespace AsphaltDelivery.Services.Data.Models.Courses
{
    using System;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class EditCourseServiceModel : IMapTo<Course>, IMapFrom<Course>
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int DriverId { get; set; }

        public int TruckId { get; set; }

        public int FirmId { get; set; }

        public int AsphaltBaseId { get; set; }

        public int AsphaltMixtureId { get; set; }

        public int RoadObjectId { get; set; }

        public double Weight { get; set; }

        public int TransportDistance { get; set; }
    }
}
