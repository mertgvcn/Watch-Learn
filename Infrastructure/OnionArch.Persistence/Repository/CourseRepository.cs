using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;

public sealed class CourseRepository(AppDbContext context) : BaseRepository<Course>(context), ICourseRepository
{
	public IQueryable<Course> GetStudentCoursesByUserId(long userId)
	{
		return GetAll().Where(a => a.Students.Any(a => a.UserId == userId));
	}
}
