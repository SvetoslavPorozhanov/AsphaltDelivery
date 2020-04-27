namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class RoadObject : BaseDeletableModel<int>
    {
        public RoadObject()
        {
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [MaxLength(AttributesConstraints.RoadObjectNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
