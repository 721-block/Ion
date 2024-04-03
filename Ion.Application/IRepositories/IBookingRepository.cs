using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IBookingRepository : IBaseRepository<Booking>
{
    Task<IEnumerable<Booking>> GetByAnnouncementIdAsync(int id);
    Task<IEnumerable<Booking>> GetByClientIdAsync(int id);
    Task<IEnumerable<Booking>> GetByAuthorIdAsync(int id);
}

