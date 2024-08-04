using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Common;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;

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

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var entry = await context.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }
    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity is IEditableEntity)
            context.Update(entity);
        else
            throw new Exception("This entity cannot be modified.");

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await DeleteAsync(await GetByIdAsync(id, cancellationToken));
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity is ISoftDeletableEntity)
        {
            var softDeletableEntity = (ISoftDeletableEntity)entity;
            softDeletableEntity.IsDeleted = true;
        }
        else if (entity is IDeletableEntity)
            context.Remove(entity);
        else
            throw new Exception("This entity cannot be deleted.");

        await context.SaveChangesAsync(cancellationToken);
    }
}
