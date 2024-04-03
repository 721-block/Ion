using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface ITripRecordRepository : IBaseRepository<TripRecord>
{
    Task<IEnumerable<TripRecord>> GeByUserIdAsync(int id);
}
