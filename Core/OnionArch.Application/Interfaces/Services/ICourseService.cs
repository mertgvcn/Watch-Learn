using OnionArch.Application.Features.Courses.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface ICourseService
{
    Task<List<CourseViewModel>> GetAllCoursesAsync();
    Task<CourseViewModel> GetCourseByIdAsync(long id);
    Task AddCourseAsync(AddCourseRequest request);
    Task UpdateCourseAsync(UpdateCourseRequest request);
    Task DeleteCourseAsync(long id);
}
