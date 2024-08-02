using OnionArch.Domain.Common;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository.Base;
public abstract class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : BaseEntity
{

    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsQueryable();
    }

    public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return (await context.Set<T>().FindAsync(id, cancellationToken))!;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await DeleteAsync(await GetByIdAsync(id, cancellationToken));
    }

    public async Task DeleteAsync(T Entity, CancellationToken cancellationToken = default)
    {
        context.Remove(Entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T Entity, CancellationToken cancellationToken = default)
    {
        context.Attach(Entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T Entity, CancellationToken cancellationToken = default)
    {
        var Entry = await context.AddAsync(Entity);
        await context.SaveChangesAsync();

        return Entry.Entity;
    }
}
