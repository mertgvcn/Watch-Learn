using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public interface ICourseRepository : IBaseRepository<Course> { }

public sealed class CourseRepository(AppDbContext context) : BaseRepository<Course>(context), ICourseRepository
{
}
