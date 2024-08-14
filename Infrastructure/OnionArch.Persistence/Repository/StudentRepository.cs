using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public sealed class StudentRepository(AppDbContext context) : BaseRepository<Student>(context), IStudentRepository
{
    public async Task<Student> GetByUserIdAsync(long userId, CancellationToken cancellationToken)
    {
        return await GetAll().Where(x => x.UserId == userId).SingleAsync(cancellationToken);
    }
}
