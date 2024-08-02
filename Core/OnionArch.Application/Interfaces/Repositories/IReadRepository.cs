using Microsoft.EntityFrameworkCore.Query;
using OnionArch.Domain.Common;
using System.Linq.Expressions;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IReadRepository<T> where T : class, IBaseEntity, new()
{
    Task<IList<T>> GetAllAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false
        );

    Task<IList<T>> GetAllByPagingAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false,
        int currentPage = 1,
        int pageSize = 3
    );

    Task<T> GetAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false
    );

    Task<T> GetByIdAsync(long id);

    Task<int> CountAsync(
        Expression<Func<T, bool>>? predicate = null
    );
    IQueryable<T> Find(
        Expression<Func<T, bool>> predicate,
        bool enableTracking = false
    );
}
