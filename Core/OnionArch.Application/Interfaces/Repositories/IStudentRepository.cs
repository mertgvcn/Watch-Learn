using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IStudentRepository : IBaseRepository<Student>
{
	IQueryable<Student> GetByUserId(long userId);
	Task<Student> GetByUserIdAsync(long userId, CancellationToken cancellationToken);
	Task<bool> IsStudentAttendedToCourse(long userId, long courseId, CancellationToken cancellationToken);
}
