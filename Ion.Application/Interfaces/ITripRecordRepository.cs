using Ion.Domain.Entities;

namespace Ion.Application.Interfaces;

public interface ITripRecordRepository : IBaseRepository<TripRecord>
{
    Task<IEnumerable<TripRecord>> GeByUserIdAsync(int id);
}
