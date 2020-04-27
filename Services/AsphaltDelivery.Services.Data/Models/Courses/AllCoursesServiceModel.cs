namespace AsphaltDelivery.Services.Data.Models.Courses
{
    using System;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class AllCoursesServiceModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Truck Truck { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual AsphaltBase AsphaltBase { get; set; }

        public virtual AsphaltMixture AsphaltMixture { get; set; }

        public virtual RoadObject RoadObject { get; set; }

        public double Weight { get; set; }

        public int TransportDistance { get; set; }

        public double WeightByDistance { get; set; }
    }
}
