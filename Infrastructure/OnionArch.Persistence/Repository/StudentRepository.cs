using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public sealed class StudentRepository(AppDbContext context) : BaseRepository<Student>(context), IStudentRepository
{
	public IQueryable<Student> GetByUserId(long userId)
	{
		return GetAll().Where(x => x.UserId == userId);
	}

	public async Task<Student> GetByUserIdAsync(long userId, CancellationToken cancellationToken)
	{
		return await GetAll().Where(x => x.UserId == userId).SingleAsync(cancellationToken);
	}

	public async Task<bool> IsStudentAttendedToCourse(long userId, long courseId, CancellationToken cancellationToken)
	{
		return await GetAll().AnyAsync(x => x.UserId == userId && x.Courses.Any(c => c.Id == courseId), cancellationToken);

	}
}
