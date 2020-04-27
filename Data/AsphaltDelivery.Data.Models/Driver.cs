namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class Driver : BaseDeletableModel<int>
    {
        public Driver()
        {
            this.DriverTrucks = new HashSet<TruckDriver>();
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [MaxLength(AttributesConstraints.DriverFullNameMaxLength)]
        public string FullName { get; set; }

        public virtual ICollection<TruckDriver> DriverTrucks { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
