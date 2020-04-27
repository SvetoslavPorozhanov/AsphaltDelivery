namespace AsphaltDelivery.Services.Data.Courses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.Courses;

    public interface ICourseService
    {
        Task<bool> ExistsAsync(int id);

        Task<List<Course>> All();

        IEnumerable<AllCoursesServiceModel> AllToCoursesServiceModel();

        Task CreateAsync(CreateCourseServiceModel createCourseServiceModel);

        Task<Course> GetByIdAsync(int id);

        Task EditAsync(EditCourseServiceModel editCourseServiceModel);

        Task DeleteByIdAsync(int id);

        Task ArchivateAsync(ArchivateCourseServiceModel archivateeCourseServiceModel);

        Task UnarchivateAsync(UnarchivateCourseServiceModel archivateeCourseServiceModel);
    }
}
