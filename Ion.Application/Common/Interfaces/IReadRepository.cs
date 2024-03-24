using Ion.Domain.Common;

namespace Ion.Application.Common.Interfaces;

public interface IReadRepository<TEntity> where TEntity : BaseEntity
{
    public IQueryable<TEntity> GetAll();

    public TEntity GetByID(int id);
}