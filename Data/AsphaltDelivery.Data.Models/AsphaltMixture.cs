namespace AsphaltDelivery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Data.Common.Models;

    public class AsphaltMixture : BaseDeletableModel<int>
    {
        public AsphaltMixture()
        {
            this.Courses = new HashSet<Course>();
        }

        [Required]
        [MaxLength(AttributesConstraints.AsphaltMixtureTypeMaxLength)]
        public string Type { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
