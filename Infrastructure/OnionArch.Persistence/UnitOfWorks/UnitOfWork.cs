using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.UnitOfWorks;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories;

namespace OnionArch.Persistence.UnitOfWorks;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async ValueTask DisposeAsync() => await context.DisposeAsync();

    public int Save() => context.SaveChanges();
    public async Task<int> SaveAsync() => await context.SaveChangesAsync();

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(context);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(context);
}
