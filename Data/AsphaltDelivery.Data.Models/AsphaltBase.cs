namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class AsphaltBase : BaseDeletableModel<int>
    {
        public AsphaltBase()
        {
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [MaxLength(AttributesConstraints.AsphaltBaseNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
