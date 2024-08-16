using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IStudentLessonProgressRepository : IBaseRepository<StudentLessonProgress>
{
	Task<List<StudentLessonProgress>> GetStudentLessonProgressesByStudentAndCourseIds(long studentId, long courseId, CancellationToken cancellationToken);
}
