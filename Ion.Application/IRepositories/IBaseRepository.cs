using Ion.Domain.Common;

namespace Ion.Application.IRepositories;

public interface IBaseRepository<TEntity> : IRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
{
}