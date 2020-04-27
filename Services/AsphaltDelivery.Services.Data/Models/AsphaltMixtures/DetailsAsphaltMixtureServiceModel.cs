namespace AsphaltDelivery.Services.Data.Models.AsphaltMixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class DetailsAsphaltMixtureServiceModel : IMapFrom<AsphaltMixture>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public IEnumerable<int> CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AsphaltMixture, DetailsAsphaltMixtureServiceModel>()
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => origin.Courses.Select(c => c.Id)));
        }
    }
}
