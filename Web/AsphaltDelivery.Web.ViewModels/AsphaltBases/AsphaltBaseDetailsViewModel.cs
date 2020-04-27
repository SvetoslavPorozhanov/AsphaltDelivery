namespace AsphaltDelivery.Web.ViewModels.AsphaltBases
{
    using System;

    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class AsphaltBaseDetailsViewModel : IMapFrom<DetailsAsphaltBaseServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CourseIds { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DetailsAsphaltBaseServiceModel, AsphaltBaseDetailsViewModel>()
                .ForMember(
                    destination => destination.CourseIds,
                    opts => opts.MapFrom(origin => string.Join(", ", origin.CourseIds)));
        }
    }
}
