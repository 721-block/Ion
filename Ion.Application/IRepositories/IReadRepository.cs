using Ion.Domain.Common;

namespace Ion.Application.IRepositories;

public interface IReadRepository<TEntity> where TEntity : BaseEntity
{
    public IEnumerable<TEntity> GetAll();

    public TEntity GetByID(int id);
}