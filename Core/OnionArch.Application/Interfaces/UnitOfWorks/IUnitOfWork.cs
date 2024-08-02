using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Common;

namespace OnionArch.Application.Interfaces.UnitOfWorks;
public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();
    Task<int> SaveAsync();
    int Save();
}
