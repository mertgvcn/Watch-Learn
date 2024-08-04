using OnionArch.Application.Features.Courses.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface ICourseService
{
    Task<List<CourseViewModel>> GetAllCoursesAsync(CancellationToken cancellationToken);
    Task<CourseViewModel> GetCourseByIdAsync(long id, CancellationToken cancellationToken);
    Task AddCourseAsync(AddCourseRequest request, CancellationToken cancellationToken);
    Task UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken);
    Task DeleteCourseAsync(long id, CancellationToken cancellationToken);
}
