using Ion.Domain.Common;

namespace Ion.Application.Common.Interfaces
{
    public interface IRepository<TEntity, Tid> where TEntity : BaseEntity<Tid> where Tid : struct
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
