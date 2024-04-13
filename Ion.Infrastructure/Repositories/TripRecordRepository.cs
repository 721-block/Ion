using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class TripRecordRepository : BaseRepository<TripRecord>, ITripRecordRepository
{
    public TripRecordRepository(CarRentContext context) : base(context)
    {
        set = context.TripRecords;
    }

    public IEnumerable<TripRecord> GeByUserId(int id)
    {
        return set.Where(t => t.UserId == id);
    }
}