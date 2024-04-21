using Ion.Application.IRepositories;
using Ion.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Ion.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected DbSet<TEntity> set;
    protected readonly CarRentContext context;

    protected BaseRepository(CarRentContext context)
    {
        this.context = context;
    }

    public async void Add(TEntity entity)
    {
        await set.AddAsync(entity);
    }

    public async void AddRange(IEnumerable<TEntity> entities)
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

    public async void SaveChanges()
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