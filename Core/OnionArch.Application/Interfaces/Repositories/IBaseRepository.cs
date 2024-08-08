using OnionArch.Domain.Common;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetById(long id);
    Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T Entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T Entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task DeleteAsync(T Entity, CancellationToken cancellationToken = default);
}