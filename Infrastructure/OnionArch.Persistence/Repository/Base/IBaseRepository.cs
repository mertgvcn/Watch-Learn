using OnionArch.Domain.Common;

namespace OnionArch.Persistence.Repository.Base;
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T Entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task DeleteAsync(T Entity, CancellationToken cancellationToken = default);
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(T Entity, CancellationToken cancellationToken = default);
}