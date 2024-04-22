using Ion.Application.IRepositories;
using Ion.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Ion.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly CarRentContext context;
    private protected DbSet<TEntity> set;

    protected BaseRepository(CarRentContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        return (await set.AddAsync(entity)).Entity;
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await set.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        set.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        set.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        set.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        set.RemoveRange(entities);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        return set;
    }

    public TEntity GetByID(int id)
    {
        return set.First(el => el.Id == id);
    }
}