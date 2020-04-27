namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
        }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        [Required]
        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; }

        [Required]
        public int FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        [Required]
        public int AsphaltBaseId { get; set; }

        public virtual AsphaltBase AsphaltBase { get; set; }

        [Required]
        public int AsphaltMixtureId { get; set; }

        public virtual AsphaltMixture AsphaltMixture { get; set; }

        [Required]
        public int RoadObjectId { get; set; }

        public virtual RoadObject RoadObject { get; set; }

        // In t
        [Required]
        [Range(typeof(double), AttributesConstraints.MinCourseWeight, AttributesConstraints.MaxCourseWeight)]
        public double Weight { get; set; }

        // In km
        [Required]
        [Range(AttributesConstraints.MinCourseDistance, AttributesConstraints.MaxCourseDistance)]
        public int TransportDistance { get; set; }

        // In tkm
        public double WeightByDistance => this.Weight * this.TransportDistance;
    }
}
