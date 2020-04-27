namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class Firm : BaseDeletableModel<int>
    {
        public Firm()
        {
            this.Trucks = new HashSet<Truck>();
            this.Drivers = new HashSet<Driver>();
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [MaxLength(AttributesConstraints.FirmNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
