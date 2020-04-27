namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class Truck : BaseDeletableModel<int>
    {
        public Truck()
        {
            this.TruckDrivers = new HashSet<TruckDriver>();
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [MaxLength(AttributesConstraints.TruckRegistrationNumberMaxLength)]
        public string RegistrationNumber { get; set; }

        public virtual ICollection<TruckDriver> TruckDrivers { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
