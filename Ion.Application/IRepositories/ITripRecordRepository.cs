using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface ITripRecordRepository : IBaseRepository<TripRecord>
{
    IEnumerable<TripRecord> GetByUserId(int id);
}
