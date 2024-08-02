using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Common;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories;
public class WriteRepository<T>(AppDbContext context) : IWriteRepository<T> where T : class, IBaseEntity, new()
{
    private DbSet<T> Table { get => context.Set<T>(); }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        if (entity is IEditableEntity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        else
        {
            throw new Exception("This entity cannot be edited");
        }
    }

    public async Task DeleteAsync(long id)
    {
        await DeleteAsync((await Table.FindAsync(id))!);
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity is ISoftDeletableEntity)
        {
            var softDeletableEntity = (ISoftDeletableEntity)entity;
            softDeletableEntity.IsDeleted = true;
        }
        else if (entity is IDeletableEntity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
        else
        {
            throw new Exception("This entity cannot be deleted");
        }
    }
}
