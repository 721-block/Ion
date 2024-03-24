using Ion.Domain.Common;
namespace Ion.Application.Common.Interfaces;

public interface IBaseRepository<TEntity> : IRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
{
}
