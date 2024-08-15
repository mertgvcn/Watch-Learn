using OnionArch.Application.Features.Courses.Models.Parameters;
using OnionArch.Application.Features.Courses.Models.Views;

namespace OnionArch.Application.Interfaces.Services;
public interface ICourseService
{
	Task<List<CourseViewModel>> GetAllCoursesAsync(CancellationToken cancellationToken);
	Task<CourseDetailViewModel> GetCourseDetailByIdAsync(long id, CancellationToken cancellationToken);
	Task<List<CurrentStudentCourseViewModel>> GetCurrentStudentCoursesAsync(CancellationToken cancellationToken);
	Task EnrollCurrentUserInCourseAsync(EnrollCurrentUserInCourseRequest request, CancellationToken cancellationToken);
	Task AddCourseAsync(AddCourseRequest request, CancellationToken cancellationToken);
	Task UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken);
}
