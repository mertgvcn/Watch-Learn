using OnionArch.Application.Features.Courses.Models;
using OnionArch.Application.Features.Students.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface IStudentService
{
	Task<List<StudentViewModel>> GetAllStudentsAsync(CancellationToken cancellationToken);
	Task<StudentViewModel> GetStudentByIdAsync(long id, CancellationToken cancellationToken);
	Task<List<CourseViewModel>> GetCoursesAttendedByCurrentStudentAsync(CancellationToken cancellationToken);
	Task<bool> IsCurrentStudentAttendedToCourseAsync(long courseId, CancellationToken cancellationToken);
	Task UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken);
}
