using Ion.Domain.Common;
namespace Ion.Application.Interfaces;

public interface IBaseRepository<TEntity> : IRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
{
}
