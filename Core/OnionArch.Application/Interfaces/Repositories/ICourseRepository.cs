using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface ICourseRepository : IBaseRepository<Course>
{
	IQueryable<Course> GetStudentCoursesByUserId(long userId);
}
