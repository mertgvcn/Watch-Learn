using OnionArch.Domain.Common;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IWriteRepository<T> where T : class, IBaseEntity, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(long id);
    Task DeleteAsync(T entity);
}
