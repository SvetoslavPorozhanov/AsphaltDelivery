namespace AsphaltDelivery.Web.ViewModels.AsphaltMixtures
{
    using System;

    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class AsphaltMixtureDetailsViewModel : IMapFrom<DetailsAsphaltMixtureServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DetailsAsphaltMixtureServiceModel, AsphaltMixtureDetailsViewModel>()
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.CourseIds)));
        }
    }
}
