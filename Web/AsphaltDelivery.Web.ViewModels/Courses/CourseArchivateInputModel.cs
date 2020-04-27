namespace AsphaltDelivery.Web.ViewModels.Courses
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using AsphaltDelivery.Services.Data.Models.Courses;
    using AsphaltDelivery.Services.Mapping;
    using AutoMapper;

    public class CourseArchivateInputModel : IMapTo<ArchivateCourseServiceModel>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Archivate courses from this year inclusive")]
        public string ArchivateFromYear { get; set; }

        [Required]
        [Display(Name = "Archivate courses to this year inclusive")]
        public string ArchivateToYear { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CourseArchivateInputModel, ArchivateCourseServiceModel>()
                .ForMember(
                    destination => destination.ArchivateFromYear,
                    opts => opts.MapFrom(origin => System.DateTime.ParseExact(origin.ArchivateFromYear, "yyyy", CultureInfo.InvariantCulture)))
                .ForMember(
                    destination => destination.ArchivateToYear,
                    opts => opts.MapFrom(origin => System.DateTime.ParseExact(origin.ArchivateToYear, "yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
