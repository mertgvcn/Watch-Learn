using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Features.Students.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface ICourseService
{
    Task<List<CourseViewModel>> GetAllCoursesAsync(CancellationToken cancellationToken);
    Task<CourseViewModel> GetCourseByIdAsync(long id, CancellationToken cancellationToken);
    Task EnrollCurrentUserInCourseAsync(EnrollCurrentUserInCourseRequest request, CancellationToken cancellationToken);
    Task AddCourseAsync(AddCourseRequest request, CancellationToken cancellationToken);
    Task UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken);
	Task<List<MyCoursesViewModel>> GetMyCourses(CancellationToken cancellationToken);
}
