using OnionArch.Application.Features.Courses.Models;

namespace OnionArch.Application.Features.Students.Models;
public sealed record CoursesAttendedByCurrentStudentViewModel
{
	public List<CourseViewModel> Courses { get; set; } = default!;
}
