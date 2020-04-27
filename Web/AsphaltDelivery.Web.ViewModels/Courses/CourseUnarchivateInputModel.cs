namespace AsphaltDelivery.Web.ViewModels.Courses
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class CourseUnarchivateInputModel : IMapTo<UnarchivateCourseServiceModel>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Unarchivate courses from this year inclusive")]
        public string UnarchivateFromYear { get; set; }

        [Required]
        [Display(Name = "Unarchivate courses to this year inclusive")]
        public string UnarchivateToYear { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CourseUnarchivateInputModel, UnarchivateCourseServiceModel>()
                .ForMember(
                    destination => destination.UnarchivateFromYear,
                    opts => opts.MapFrom(origin => System.DateTime.ParseExact(origin.UnarchivateFromYear, "yyyy", CultureInfo.InvariantCulture)))
                .ForMember(
                    destination => destination.UnarchivateToYear,
                    opts => opts.MapFrom(origin => System.DateTime.ParseExact(origin.UnarchivateToYear, "yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
