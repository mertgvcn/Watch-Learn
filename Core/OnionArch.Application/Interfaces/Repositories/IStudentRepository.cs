using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IStudentRepository : IBaseRepository<Student>
{
    Task<Student> GetByUserIdAsync(long userId, CancellationToken cancellationToken);
}
