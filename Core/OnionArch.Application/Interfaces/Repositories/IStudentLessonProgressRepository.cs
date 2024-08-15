using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IStudentLessonProgressRepository : IBaseRepository<StudentLessonProgress>
{
	Task<StudentLessonProgress> GetByStudentAndLessonIds(long studentId, long lessonId, CancellationToken cancellationToken);
}
