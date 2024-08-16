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

	public IQueryable<T> GetById(long id)
	{
		return GetAll().Where(x => x.Id == id);
	}

	public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
	{
		return (await context.Set<T>().FindAsync(id, cancellationToken))!;
	}

	public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
	{
		var entry = await context.AddAsync(entity, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return entry.Entity;
	}

	public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		await context.AddRangeAsync(entities, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
	{
		if (entity is IEditableEntity)
			context.Attach(entity);
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
