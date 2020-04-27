namespace AsphaltDelivery.Web.ViewModels.RoadObjects
{
    using System;

    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class RoadObjectDetailsViewModel : IMapFrom<DetailsRoadObjectServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DetailsRoadObjectServiceModel, RoadObjectDetailsViewModel>()
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.CourseIds)));
        }
    }
}
